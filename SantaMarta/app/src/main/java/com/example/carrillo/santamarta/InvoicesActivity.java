package com.example.carrillo.santamarta;

import android.app.Activity;
import android.app.ProgressDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AppCompatActivity;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.io.IOException;
import java.io.OutputStream;
import java.nio.ByteBuffer;
import java.text.DecimalFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Set;
import java.util.Timer;
import java.util.TimerTask;
import java.util.UUID;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class InvoicesActivity extends AppCompatActivity implements Runnable{
    protected static final String TAG = "TAG";
    private static final int REQUEST_CONNECT_DEVICE = 1;
    private static final int REQUEST_ENABLE_BT = 2;
    Button mScan, mPrint, mDisc;
    BluetoothAdapter mBluetoothAdapter;
    private UUID applicationUUID = UUID
            .fromString("00001101-0000-1000-8000-00805F9B34FB");
    private ProgressDialog mBluetoothConnectProgressDialog;
    private static BluetoothSocket mBluetoothSocket;
    BluetoothDevice mBluetoothDevice;

    private static ListView list;
    private CheckBox checkExpired;
    private Button add;
    private Button back;
    private static String token = "";
    private static Contextdb contextdb = new Contextdb();
    private static List<Invoice> listInvoices;
    private static List<Invoice> listInvoicesSearch;
    private static Context context;
    private static String[] type ;
    public static Invoice invoice;
    private EditText txtsearch;
    private TextWatcher text = null;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invoices);
        //final ListView list = (ListView) findViewById(R.id.list_invoices);
        txtsearch = (EditText) findViewById(R.id.txt_search);
        list = (ListView) findViewById(R.id.list_invoices);
        add = (Button) findViewById(R.id.btn_add);
        back = (Button) findViewById(R.id.btn_back);
        checkExpired = (CheckBox) findViewById(R.id.cb_expired);
        token = MainActivity.token;
        context = getBaseContext();
        final Contextdb contextdb = new Contextdb();
        listInvoices = contextdb.getAllInvoices(token);
        display();

        text = new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                listInvoicesSearch = null;
                if (txtsearch.getText().toString().equals("")) {
                    display();
                } else {
                    for (int x = 0; x < listInvoices.size(); x++) {
                        invoice = listInvoices.get(x);
                        if (invoice.getName().compareTo(txtsearch.getText().toString()) == 1) {
                            listInvoicesSearch.add(new Invoice(invoice.getIDInvoice(), invoice.getLimitDate(), invoice.getCurrentDate(), invoice.getCode(),
                                    invoice.getTotal(), invoice.getState(), invoice.getName(), invoice.getNameCompany(), invoice.getRode()));
                        } else if (invoice.getNameCompany().compareTo(txtsearch.getText().toString()) == 1) {
                            listInvoicesSearch.add(new Invoice(invoice.getIDInvoice(), invoice.getLimitDate(), invoice.getCurrentDate(), invoice.getCode(),
                                    invoice.getTotal(), invoice.getState(), invoice.getName(), invoice.getNameCompany(), invoice.getRode()));
                        } else if (invoice.getName().startsWith(txtsearch.getText().toString()) == true) {
                            listInvoicesSearch.add(new Invoice(invoice.getIDInvoice(), invoice.getLimitDate(), invoice.getCurrentDate(), invoice.getCode(),
                                    invoice.getTotal(), invoice.getState(), invoice.getName(), invoice.getNameCompany(), invoice.getRode()));
                        } else if (invoice.getNameCompany().startsWith(txtsearch.getText().toString()) == true) {
                            listInvoicesSearch.add(new Invoice(invoice.getIDInvoice(), invoice.getLimitDate(), invoice.getCurrentDate(), invoice.getCode(),
                                    invoice.getTotal(), invoice.getState(), invoice.getName(), invoice.getNameCompany(), invoice.getRode()));
                        }
                        displaySearch();
                    }
                }
            }
            @Override
            public void afterTextChanged(Editable s) {

            }
        };

        txtsearch.addTextChangedListener(text);

        checkExpired.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
        {
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
            {
                if (checkExpired.isChecked()==true) {
                    listInvoices = contextdb.getAllInvoicesExpired(token);
                    display();
                }
                if (checkExpired.isChecked()==false) {
                    listInvoices = contextdb.getAllInvoices(token);
                    display();
                }
            }
        });

        list.setOnItemClickListener(new android.widget.AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(position>=0){
                    if(type[position] =="0" || type[position] =="2" || type[position] =="3"){
                        session();
                        if(mBluetoothAdapter==null){
                            Toast.makeText(getApplicationContext(), "Impresora no conectada, por favor conecte el dispocitivo", Toast.LENGTH_LONG).show();
                            // SLEEP 2 SECONDS HERE ...
                            final Handler handler = new Handler();
                            Timer t = new Timer();
                            t.schedule(new TimerTask() {
                                public void run() {
                                    handler.post(new Runnable() {
                                        public void run() {
                                            mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
                                            if (!mBluetoothAdapter.isEnabled()) {
                                                Intent enableBtIntent = new Intent(
                                                        BluetoothAdapter.ACTION_REQUEST_ENABLE);
                                                startActivityForResult(enableBtIntent,
                                                        REQUEST_ENABLE_BT);
                                            } else {
                                                ListPairedDevices();
                                                Intent connectIntent = new Intent(InvoicesActivity.this,
                                                        DeviceListActivity.class);
                                                startActivityForResult(connectIntent,
                                                        REQUEST_CONNECT_DEVICE);
                                            }
                                        }
                                    });
                                }
                            }, 1000);
                        }else {
                            invoice = listInvoices.get(position);
                            Intent menu = new Intent(InvoicesActivity.this, AssetsliabilitiesActivity.class);
                            startActivity(menu);
                        }
                    }
                }
            }
        });

        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(InvoicesActivity.this, MenuActivity.class);
                startActivity(menu);
                finish();
            }
        });

        add.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                session();
                if(mBluetoothAdapter==null){
                    Toast.makeText(getApplicationContext(), "Impresora no conectada, por favor conecte el dispocitivo", Toast.LENGTH_LONG).show();
                    // SLEEP 2 SECONDS HERE ...
                    final Handler handler = new Handler();
                    Timer t = new Timer();
                    t.schedule(new TimerTask() {
                        public void run() {
                            handler.post(new Runnable() {
                                public void run() {
                                    mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
                                    if (!mBluetoothAdapter.isEnabled()) {
                                        Intent enableBtIntent = new Intent(
                                                BluetoothAdapter.ACTION_REQUEST_ENABLE);
                                        startActivityForResult(enableBtIntent,
                                                REQUEST_ENABLE_BT);
                                    } else {
                                        ListPairedDevices();
                                        Intent connectIntent = new Intent(InvoicesActivity.this,
                                                DeviceListActivity.class);
                                        startActivityForResult(connectIntent,
                                                REQUEST_CONNECT_DEVICE);
                                    }
                                }
                            });
                        }
                    }, 1000);
                }else {
                    Intent invoice = new Intent(InvoicesActivity.this, InsertInvoiceActivity.class);
                    startActivity(invoice);
                }
            }
        });

    }
    public static void refresh(){
        listInvoices = contextdb.getAllInvoices(token);
        if (listInvoices.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Facturas no encontradas");

            ArrayAdapter<String> adapter = new ArrayAdapter<>(context, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            final String[] color = new String[listInvoices.size()];
            Invoice invoice;
            String dateNow="";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 1);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            dateNow = format.format(date);

            for(int x =0; x < listInvoices.size(); x++){
                invoice = listInvoices.get(x);
                SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
                try {
                    Date date_now = formatter.parse(dateNow.toString());
                    Date date_curent = formatter.parse(invoice.getCurrentDate().toString());
                    Date date_limit = formatter.parse(invoice.getLimitDate().toString());
                    if(date_curent.equals(date_limit)){
                        if(invoice.getTotal() == 0.0){
                            color[x] = "1";
                        }else {
                            color[x] = "0";
                        }
                    }else {
                        if(invoice.getTotal() == 0){
                            color[x] = "1";
                        }else if(date_limit.after(date_now) && invoice.getTotal() != invoice.getRode()){
                            color[x] = "2";
                        }else if(date_limit.before(date_now) && invoice.getTotal() != invoice.getRode()) {
                            color[x] = "3";
                        }
                    }
                    if(invoice.getState().toString().equals("false")){
                        color[x] = "4";
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }
            }

            final ArrayAdapter arrayAdapter2 = new ArrayAdapter
                    (context, android.R.layout.simple_list_item_1, listInvoices){
                @Override
                public View getView(int position, View convertView, ViewGroup parent){

                    View view = super.getView(position,convertView,parent);
                    if(color[position] == "0")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }
                    else if(color[position] == "1")
                    {
                        view.setBackgroundColor(Color.parseColor("#2bc81e"));
                    }else if(color[position] == "2")
                    {
                        view.setBackgroundColor(Color.parseColor("#ffbf00"));
                    }else if(color[position] == "3")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }else if(color[position] == "4")
                    {
                        view.setBackgroundColor(Color.parseColor("#a4a4a4"));
                    }
                    return view;
                }
            };
            type = color;
// DataBind ListView with items from ArrayAdapter
            list.setAdapter(arrayAdapter2);


        }
    }
    public void display() {
        if (listInvoices.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Facturas no encontradas");

            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            final String[] color = new String[listInvoices.size()];
            Invoice invoice;
            String dateNow="";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 1);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            dateNow = format.format(date);

            for(int x =0; x < listInvoices.size(); x++){
                invoice = listInvoices.get(x);
                SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
                try {
                    Date date_now = formatter.parse(dateNow.toString());
                    Date date_curent = formatter.parse(invoice.getCurrentDate().toString());
                    Date date_limit = formatter.parse(invoice.getLimitDate().toString());
                    if(date_curent.equals(date_limit)){
                        if(invoice.getTotal() == 0.0){
                            color[x] = "1";
                        }else {
                            color[x] = "0";
                        }
                    }else {
                        if(invoice.getTotal() == 0.0){
                            color[x] = "1";
                        }else if(date_limit.after(date_now) && invoice.getTotal() != invoice.getRode()){
                            color[x] = "2";
                        }else if(date_limit.before(date_now) && invoice.getTotal() != invoice.getRode()) {
                            color[x] = "3";
                        }
                    }
                    if(invoice.getState().toString().equals("false")){
                        color[x] = "4";
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }
            }

            final ArrayAdapter arrayAdapter2 = new ArrayAdapter
                    (context, android.R.layout.simple_list_item_1, listInvoices){
                @Override
                public View getView(int position, View convertView, ViewGroup parent){

                    View view = super.getView(position,convertView,parent);
                    if(color[position] == "0")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }
                    else if(color[position] == "1")
                    {
                        view.setBackgroundColor(Color.parseColor("#2bc81e"));
                    }else if(color[position] == "2")
                    {
                        view.setBackgroundColor(Color.parseColor("#ffbf00"));
                    }else if(color[position] == "3")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }else if(color[position] == "4")
                    {
                        view.setBackgroundColor(Color.parseColor("#a4a4a4"));
                    }
                    return view;
                }
            };
            type = color;
// DataBind ListView with items from ArrayAdapter
            list.setAdapter(arrayAdapter2);


        }
    }
    public void displaySearch() {
        if (listInvoicesSearch.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Facturas no encontradas");

            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            final String[] color = new String[listInvoicesSearch.size()];
            Invoice invoice;
            String dateNow="";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 1);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            dateNow = format.format(date);

            for(int x =0; x < listInvoicesSearch.size(); x++){
                invoice = listInvoicesSearch.get(x);
                SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
                try {
                    Date date_now = formatter.parse(dateNow.toString());
                    Date date_curent = formatter.parse(invoice.getCurrentDate().toString());
                    Date date_limit = formatter.parse(invoice.getLimitDate().toString());
                    if(date_curent.equals(date_limit)){
                        if(invoice.getTotal() == 0.0){
                            color[x] = "1";
                        }else {
                            color[x] = "0";
                        }
                    }else {
                        if(invoice.getTotal() == 0){
                            color[x] = "1";
                        }else if(date_limit.after(date_now) && invoice.getTotal() != invoice.getRode()){
                            color[x] = "2";
                        }else if(date_limit.before(date_now) && invoice.getTotal() != invoice.getRode()) {
                            color[x] = "3";
                        }
                    }
                    if(invoice.getState().toString().equals("false")){
                        color[x] = "4";
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }
            }

            final ArrayAdapter arrayAdapter2 = new ArrayAdapter
                    (context, android.R.layout.simple_list_item_1, listInvoices){
                @Override
                public View getView(int position, View convertView, ViewGroup parent){

                    View view = super.getView(position,convertView,parent);
                    if(color[position] == "0")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }
                    else if(color[position] == "1")
                    {
                        view.setBackgroundColor(Color.parseColor("#2bc81e"));
                    }else if(color[position] == "2")
                    {
                        view.setBackgroundColor(Color.parseColor("#ffbf00"));
                    }else if(color[position] == "3")
                    {
                        view.setBackgroundColor(Color.parseColor("#ec3e3e"));
                    }else if(color[position] == "4")
                    {
                        view.setBackgroundColor(Color.parseColor("#a4a4a4"));
                    }
                    return view;
                }
            };
            type = color;
// DataBind ListView with items from ArrayAdapter
            list.setAdapter(arrayAdapter2);
        }
    }
    @Override
    protected void onDestroy() {
        // TODO Auto-generated method stub
        super.onDestroy();
        try {
            if (mBluetoothSocket != null)
                mBluetoothSocket.close();
        } catch (Exception e) {
            Log.e("Tag", "Exe ", e);
        }
    }

    @Override
    public void onBackPressed() {
        try {
            if (mBluetoothSocket != null)
                mBluetoothSocket.close();
        } catch (Exception e) {
            Log.e("Tag", "Exe ", e);
        }
        setResult(RESULT_CANCELED);
        finish();
    }

    public void onActivityResult(int mRequestCode, int mResultCode,
                                 Intent mDataIntent) {
        super.onActivityResult(mRequestCode, mResultCode, mDataIntent);

        switch (mRequestCode) {
            case REQUEST_CONNECT_DEVICE:
                if (mResultCode == Activity.RESULT_OK) {
                    Bundle mExtra = mDataIntent.getExtras();
                    String mDeviceAddress = mExtra.getString("DeviceAddress");
                    Log.v(TAG, "Coming incoming address " + mDeviceAddress);
                    mBluetoothDevice = mBluetoothAdapter
                            .getRemoteDevice(mDeviceAddress);
                    mBluetoothConnectProgressDialog = ProgressDialog.show(this,
                            "Connecting...", mBluetoothDevice.getName() + " : "
                                    + mBluetoothDevice.getAddress(), true, false);
                    Thread mBlutoothConnectThread = new Thread(this);
                    mBlutoothConnectThread.start();
                    // pairToDevice(mBluetoothDevice); This method is replaced by
                    // progress dialog with thread
                }
                break;

            case REQUEST_ENABLE_BT:
                if (mResultCode == Activity.RESULT_OK) {
                    ListPairedDevices();
                    Intent connectIntent = new Intent(InvoicesActivity.this,
                            DeviceListActivity.class);
                    startActivityForResult(connectIntent, REQUEST_CONNECT_DEVICE);
                } else {
                    Toast.makeText(InvoicesActivity.this, "Message", Toast.LENGTH_SHORT).show();
                }
                break;
        }
    }

    private void ListPairedDevices() {
        Set<BluetoothDevice> mPairedDevices = mBluetoothAdapter
                .getBondedDevices();
        if (mPairedDevices.size() > 0) {
            for (BluetoothDevice mDevice : mPairedDevices) {
                Log.v(TAG, "PairedDevices: " + mDevice.getName() + "  "
                        + mDevice.getAddress());
            }
        }
    }

    public void run() {
        try {
            mBluetoothSocket = mBluetoothDevice
                    .createRfcommSocketToServiceRecord(applicationUUID);
            mBluetoothAdapter.cancelDiscovery();
            mBluetoothSocket.connect();
            mHandler.sendEmptyMessage(0);
        } catch (IOException eConnectException) {
            Log.d(TAG, "CouldNotConnectToSocket", eConnectException);
            closeSocket(mBluetoothSocket);
            return;
        }
    }

    private void closeSocket(BluetoothSocket nOpenSocket) {
        try {
            nOpenSocket.close();
            Log.d(TAG, "SocketClosed");
        } catch (IOException ex) {
            Log.d(TAG, "CouldNotCloseSocket");
        }
    }

    private Handler mHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            mBluetoothConnectProgressDialog.dismiss();
            Toast.makeText(InvoicesActivity.this, "DeviceConnected", Toast.LENGTH_SHORT).show();
        }
    };

    public static byte intToByteArray(int value) {
        byte[] b = ByteBuffer.allocate(4).putInt(value).array();

        for (int k = 0; k < b.length; k++) {
            System.out.println("Selva  [" + k + "] = " + "0x"
                    + UnicodeFormatter.byteToHex(b[k]));
        }

        return b[3];
    }

    public byte[] sel(int val) {
        ByteBuffer buffer = ByteBuffer.allocate(2);
        buffer.putInt(val);
        buffer.flip();
        return buffer.array();
    }
    public static void printInvoice(final String client, final String numInvoice, final String dateCurent, final String credit, final List<Product> productlist,
                                          final String discount, final String total){
        final DecimalFormat df = new DecimalFormat("#.00");
        Thread t = new Thread() {
            public void run() {
                Product product;
                try {
                    OutputStream os = mBluetoothSocket
                            .getOutputStream();
                    String BILL = "";

                    BILL = "     PRODUCTOS ALIMENTICIOS \n"
                            + "          SANTA MARTA \n" +
                            "      Telefono: 2473 15 16 \n" +
                            "        Factura de venta     \n" +
                            "Numero de Factura: "+numInvoice+"\n" +
                            "Fecha: " + dateCurent +"\n" +
                            "Cliente: \n" +
                            ""+ client + "\n";
                    BILL = BILL
                            + "-------------------------------\n";


                    BILL = BILL + " Nombre          Codigo ";
                    BILL = BILL + "\n";
                    BILL = BILL
                            + "-------------------------------\n";
                    for(int x=0; x<productlist.size();x++) {
                        product = productlist.get(x);
                        BILL = BILL + "\n " + product.getName()+"    "+product.getCode();
                    }
                    BILL = BILL
                            + "\n-------------------------------\n";
                    BILL = BILL + "\n\n ";

                    BILL = BILL + "Cantidad Impuesto  Total";
                    BILL = BILL + "\n";
                    BILL = BILL
                            + "-------------------------------\n";
                    for(int x=0; x<productlist.size();x++) {
                        product = productlist.get(x);
                        BILL = BILL + "\n " + product.getQuantity()+"    "+product.getTax()+"   "+df.format(product.getTotal());
                    }

                    BILL = BILL
                            + "\n-------------------------------";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";

                    BILL = BILL + " Descuento: " + discount + " %" + "\n";
                    BILL = BILL + " Total de Factura: \n";
                    BILL = BILL + " "+ total +"\n";

                    BILL = BILL
                            + "-------------------------------\n";
                    BILL = BILL + "\n";
                    BILL = BILL + "  Mejorando la calidad cada dia \n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    os.write(BILL.getBytes());
                    //This is printer specific code you can comment ==== > Start

                    // Setting height
                    int gs = 29;
                    os.write(intToByteArray(gs));
                    int h = 104;
                    os.write(intToByteArray(h));
                    int n = 162;
                    os.write(intToByteArray(n));

                    // Setting Width
                    int gs_width = 29;
                    os.write(intToByteArray(gs_width));
                    int w = 119;
                    os.write(intToByteArray(w));
                    int n_width = 2;
                    os.write(intToByteArray(n_width));


                } catch (Exception e) {
                    Log.e("MainPrintActivity", "Exe ", e);
                }
            }
        };
        t.start();
    }
    public static void printInvoiceCredit(final String client, final String numInvoice, final String dateCurent, final String dateLimit, final String credit, final List<Product> productlist,
                                    final String discount, final String total){
        final DecimalFormat df = new DecimalFormat("#.00");
        Thread t = new Thread() {
            public void run() {
                Product product;
                try {
                    OutputStream os = mBluetoothSocket
                            .getOutputStream();
                    String BILL = "";

                    BILL = "     PRODUCTOS ALIMENTICIOS \n"
                            + "          SANTA MARTA \n" +
                            "      Telefono: 2473 15 16 \n" +
                            "        Factura de venta     \n" +
                            "Numero de Factura: "+numInvoice+"\n" +
                            "Fecha: " + dateCurent +"\n" +
                            "Fecha Limite: \n" +
                            ""+ dateLimit + " \n" +
                            "Cliente: \n" +
                            ""+ client + "\n";
                    BILL = BILL
                            + "-------------------------------\n";


                    BILL = BILL + " Nombre          Codigo ";
                    BILL = BILL + "\n";
                    BILL = BILL
                            + "-------------------------------\n";
                    for(int x=0; x<productlist.size();x++) {
                        product = productlist.get(x);
                        BILL = BILL + "\n " + product.getName()+"    "+product.getCode();
                    }
                    BILL = BILL
                            + "\n-------------------------------\n";
                    BILL = BILL + "\n\n ";

                    BILL = BILL + "Cantidad Impuesto  Total";
                    BILL = BILL + "\n";
                    BILL = BILL
                            + "-------------------------------\n";
                    for(int x=0; x<productlist.size();x++) {
                        product = productlist.get(x);
                        BILL = BILL + "\n " + product.getQuantity()+"    "+product.getTax()+"   "+df.format(product.getTotal());
                    }

                    BILL = BILL
                            + "\n-------------------------------";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";

                    BILL = BILL + " Descuento: " + discount + " %" + "\n";
                    BILL = BILL + " Total de Factura: \n";
                    BILL = BILL + " "+ total +"\n";

                    BILL = BILL
                            + "-------------------------------\n";
                    BILL = BILL + "\n";
                    BILL = BILL + "  Mejorando la calidad cada dia \n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    os.write(BILL.getBytes());
                    //This is printer specific code you can comment ==== > Start

                    // Setting height
                    int gs = 29;
                    os.write(intToByteArray(gs));
                    int h = 104;
                    os.write(intToByteArray(h));
                    int n = 162;
                    os.write(intToByteArray(n));

                    // Setting Width
                    int gs_width = 29;
                    os.write(intToByteArray(gs_width));
                    int w = 119;
                    os.write(intToByteArray(w));
                    int n_width = 2;
                    os.write(intToByteArray(n_width));


                } catch (Exception e) {
                    Log.e("MainPrintActivity", "Exe ", e);
                }
            }
        };
        t.start();
    }
    public static void printRode(final String client, final String numInvoice, final String dateCurent, final String totalInvoice,
                                    final String totalRode, final String total){
        final DecimalFormat df = new DecimalFormat("#.00");
        Thread t = new Thread() {
            public void run() {
                Product product;
                try {
                    OutputStream os = mBluetoothSocket
                            .getOutputStream();
                    String BILL = "";

                    BILL = "     PRODUCTOS ALIMENTICIOS \n"
                            + "          SANTA MARTA \n" +
                            "      Telefono: 2473 15 16 \n" +
                            "        Recibo de Abono     \n" +
                            "Numero de Factura: "+numInvoice+"\n" +
                            "Fecha: " + dateCurent +"\n" +
                            "Cliente: \n" +
                            ""+ client + "\n";

                    BILL = BILL
                            + "\n-------------------------------";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";

                    BILL = BILL + "Total de Cuenta: \n" +
                            ""+ totalInvoice + "\n";
                    BILL = BILL + "Total de Abonos: \n" +
                            ""+ totalRode + "\n";
                    BILL = BILL + "Total Abonado: \n" +
                            ""+ total + "\n";

                    BILL = BILL
                            + "-------------------------------\n";

                    BILL = BILL + "\n";
                    BILL = BILL + "  Mejorando la calidad cada dia \n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    BILL = BILL + "\n";
                    os.write(BILL.getBytes());
                    //This is printer specific code you can comment ==== > Start

                    // Setting height
                    int gs = 29;
                    os.write(intToByteArray(gs));
                    int h = 104;
                    os.write(intToByteArray(h));
                    int n = 162;
                    os.write(intToByteArray(n));

                    // Setting Width
                    int gs_width = 29;
                    os.write(intToByteArray(gs_width));
                    int w = 119;
                    os.write(intToByteArray(w));
                    int n_width = 2;
                    os.write(intToByteArray(n_width));


                } catch (Exception e) {
                    Log.e("MainPrintActivity", "Exe ", e);
                }
            }
        };
        t.start();
    }
    public void session(){
        String responce = contextdb.getSession(token);
        if(responce.toString().equals("false")){
            Toast.makeText(getApplicationContext(), "Sesión expirada, por favor vuelva a loguear su cuenta!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            finish();
                        }
                    });
                }
            }, 1000);
        }else if(responce.toString().equals("error")){
            Toast.makeText(getApplicationContext(), "Error en la conexion con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            finish();
                        }
                    });
                }
            }, 1000);
        }
    }
}
