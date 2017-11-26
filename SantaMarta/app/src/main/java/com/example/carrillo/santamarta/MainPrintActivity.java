package com.example.carrillo.santamarta;

/**
 * Created by joser on 16/11/2017.
 */

import java.io.IOException;
import java.io.OutputStream;
import java.nio.ByteBuffer;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Set;
import java.util.UUID;

import android.app.Activity;
import android.app.ProgressDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;


public class MainPrintActivity extends Activity implements Runnable {
    protected static final String TAG = "TAG";
    private static final int REQUEST_CONNECT_DEVICE = 1;
    private static final int REQUEST_ENABLE_BT = 2;
    Button mScan, mPrint, mDisc, mBack;
    static BluetoothAdapter mBluetoothAdapter;
    private static UUID applicationUUID = UUID
            .fromString("00001101-0000-1000-8000-00805F9B34FB");
    private static ProgressDialog mBluetoothConnectProgressDialog;
    private static BluetoothSocket mBluetoothSocket;
    static BluetoothDevice mBluetoothDevice;

    @Override
    public void onCreate(Bundle mSavedInstanceState) {
        super.onCreate(mSavedInstanceState);
        setContentView(R.layout.activity_main_print);
        mBack = (Button) findViewById(R.id.back);
        mScan = (Button) findViewById(R.id.Scan);
        mScan.setOnClickListener(new View.OnClickListener() {
            public void onClick(View mView) {
                mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
                if (mBluetoothAdapter == null) {
                    Toast.makeText(MainPrintActivity.this, "Message1", Toast.LENGTH_SHORT).show();
                } else {
                    if (!mBluetoothAdapter.isEnabled()) {
                        Intent enableBtIntent = new Intent(
                                BluetoothAdapter.ACTION_REQUEST_ENABLE);
                        startActivityForResult(enableBtIntent,
                                REQUEST_ENABLE_BT);
                    } else {
                        ListPairedDevices();
                        Intent connectIntent = new Intent(MainPrintActivity.this,
                                DeviceListActivity.class);
                        startActivityForResult(connectIntent,
                                REQUEST_CONNECT_DEVICE);
                    }
                }
            }
        });
        mBack.setOnClickListener(new View.OnClickListener() {
            public void onClick(View mView) {
                Intent menu = new Intent(MainPrintActivity.this, MenuActivity.class);
                startActivity(menu);
            }
        });
        mPrint = (Button) findViewById(R.id.mPrint);
        mPrint.setOnClickListener(new View.OnClickListener() {
            public void onClick(View mView) {
                Thread t = new Thread() {
                    public void run() {
                        String dateCredit="";
                        Date date = new Date();
                        Calendar calendar = Calendar.getInstance();
                        calendar.add(Calendar.DATE, 1);
                        date = calendar.getTime();
                        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                        dateCredit = format.format(date);
                        try {
                            OutputStream os = mBluetoothSocket
                                    .getOutputStream();
                            String BILL = "";

                            BILL = "     PRODUCTOS ALIMENTICIOS \n"
                                    + "          SANTA MARTA \n" +
                                    "        Factura de venta     \n" +
                                    "Numero de Factura: 0001 \n" +
                                    "Fecha: " + dateCredit.toString() +"\n" +
                                    "Credito: si \n" +
                                    "Fecha Limite: \n" +
                                    ""+ dateCredit.toString() + " \n" +
                                    "Cliente: Super el Grande \n";
                            BILL = BILL
                                    + "-------------------------------\n";


                            BILL = BILL + " Nombre          Codigo ";
                            BILL = BILL + "\n";
                            BILL = BILL
                                    + "-------------------------------\n";
                            BILL = BILL + "\n " + "Pan Blanco      item-001 ";
                            BILL = BILL + "\n " + "Pan Integral    item-002 ";
                            BILL = BILL + "\n " + "Manitas         item-003 ";
                            BILL = BILL + "\n " + "Bollos          item-004 ";

                            BILL = BILL
                                    + "\n-------------------------------\n";
                            BILL = BILL + "\n\n ";

                            BILL = BILL + "Cantidad Impuesto  Total";
                            BILL = BILL + "\n";
                            BILL = BILL
                                    + "-------------------------------\n";
                            BILL = BILL + "\n " + "  50         0     150.00";
                            BILL = BILL + "\n " + "  20         0     75.00";
                            BILL = BILL + "\n " + "  10         0     100.00";
                            BILL = BILL + "\n " + "  30         0     120.00";

                            BILL = BILL
                                    + "\n-------------------------------";
                            BILL = BILL + "\n";
                            BILL = BILL + "\n";

                            BILL = BILL + " Descuento: " + "3" + " %" + "\n";
                            BILL = BILL + " Total de Factura: \n";
                            BILL = BILL + " 431.65 \n";

                            BILL = BILL
                                    + "-------------------------------\n";
                            BILL = BILL + "\n";
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
        });

        mDisc = (Button) findViewById(R.id.dis);
        mDisc.setOnClickListener(new View.OnClickListener() {
            public void onClick(View mView) {
                if (mBluetoothAdapter != null)
                    mBluetoothAdapter.disable();
            }
        });

    }// onCreate

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
                    Intent connectIntent = new Intent(MainPrintActivity.this,
                            DeviceListActivity.class);
                    startActivityForResult(connectIntent, REQUEST_CONNECT_DEVICE);
                } else {
                    Toast.makeText(MainPrintActivity.this, "Message", Toast.LENGTH_SHORT).show();
                }
                break;
        }
    }

    public static void ListPairedDevices() {
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
            Toast.makeText(MainPrintActivity.this, "DeviceConnected", Toast.LENGTH_SHORT).show();
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
    public static void create(){

    }
    public static void printInvoice(final String client, final String numInvoice, final String dateCurent, final String dateLimit, final String credit, final List<Product> productlist,
                                    final String discount, final String total){
        Thread t = new Thread() {
            public void run() {
                Product product;
                try {
                    OutputStream os = mBluetoothSocket
                            .getOutputStream();
                    String BILL = "";

                    BILL = "     PRODUCTOS ALIMENTICIOS \n"
                            + "          SANTA MARTA \n" +
                            "        Factura de venta     \n" +
                            "Numero de Factura: "+numInvoice+"\n" +
                            "Fecha: " + dateCurent +"\n" +
                            "Credito: "+credit+"\n" +
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
                        BILL = BILL + "\n " + product.getQuantity()+"    "+product.getTax()+"   "+product.getTotal();
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
}
