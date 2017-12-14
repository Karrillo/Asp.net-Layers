package com.example.carrillo.santamarta;

import android.content.SharedPreferences;
import android.os.StrictMode;
import android.util.Log;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import static android.content.Context.MODE_PRIVATE;

/**
 * Created by Carrillo on 10/4/2017.
 */

public class Contextdb {

    public String getCheck(String nickname, String password) {
        String sql = "http://192.168.0.2:49161/api/User";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("nickname", nickname);
            params.put("password", password);

            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

            String inputLine;

            StringBuffer response = new StringBuffer();

            String json = "";

            while ((inputLine = in.readLine()) != null) {
                response.append(inputLine);
            }

            json = response.toString();

            if (!json.equals("500")) {
                JSONObject jsonArr = null;

                jsonArr = new JSONObject(json);

                return jsonArr.optString("IDUser");
            } else {
                return "0";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "false";
        } catch (IOException e) {
            e.printStackTrace();
            return "false";
        } catch (JSONException e) {
            e.printStackTrace();
            return "false";
        }
    }

    public String getToken() {
        String sql = "http://192.168.0.2:49161/token";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("grant_type", "password");


            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONObject jsonArr = null;

                jsonArr = new JSONObject(json);
                String token = "";

                token = jsonArr.optString("access_token");

                return token;
            }else {
                return "error";
            }

        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "error";
        } catch (IOException e) {
            e.printStackTrace();
            return "error";
        } catch (JSONException e) {
            e.printStackTrace();
            return "error";
        }
    }
    public String getSession(String token) {
        String sql = "http://192.168.0.2:49161/api/User/GetSession";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setReadTimeout(60 * 1000);
            conn.setConnectTimeout(60 * 1000);
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                return "true";
            }else if (responseCode == 401){
                return "false";
            }else {
                return "error";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "error";
        } catch (IOException e) {
            e.printStackTrace();
            return "error";
        }
    }
    public List<Client> getAllClients(String token) {
        String sql = "http://192.168.0.2:49161/api/Client";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Client> listClients = new ArrayList<Client>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    if(!jsonObject.optString("NameCompany").equals("null")){
                        listClients.add(new Client(Integer.parseInt(jsonObject.optString("IDClient")),jsonObject.optString("Name"),jsonObject.optString("FirstName"),
                                jsonObject.optString("SecondName"),jsonObject.optString("Email"),jsonObject.optString("Phone"),jsonObject.optString("CellPhone")
                                ,jsonObject.optString("Address"),jsonObject.optString("NameCompany"),jsonObject.optString("Code")));
                    }else {
                        listClients.add(new Client(Integer.parseInt(jsonObject.optString("IDClient")),jsonObject.optString("Name"),jsonObject.optString("FirstName"),
                                jsonObject.optString("SecondName"),jsonObject.optString("Email"),jsonObject.optString("Phone"),jsonObject.optString("CellPhone")
                                ,jsonObject.optString("Address"),jsonObject.optString("N/D"),jsonObject.optString("Code")));
                    }
                }
            }else if (responseCode == 401){
                return listClients;
            }else {
                return listClients;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listClients;
        } catch (IOException e) {
            e.printStackTrace();
            return listClients;
        } catch (JSONException e) {
            e.printStackTrace();
            return listClients;
        }
        return listClients;
    }

    public String insertClients(Client client, String token) {
        String sql = "http://192.168.0.2:49161/api/Client";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("Name", client.getName());
            params.put("FirstName", client.getFirstName());
            params.put("SecondName", client.getSecondName());
            params.put("Email", client.getEmail());
            params.put("Phone", client.getPhone());
            params.put("CellPhone", client.getCellPhone());
            params.put("Address", client.getAddress());
            params.put("NameCompany", client.getNameCompany());
            params.put("Code", client.getCode());

            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if(json.toString().equals("200")){
                    return "200";
                }else if (json.toString().equals("400")){
                    return "400";
                }else if (json.toString().equals("401")){
                    return "401";
                }else {
                    return "500";
                }
            }else if (responseCode == 401){
                return "500";
            }else {
                return "500";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "500";
        } catch (IOException e) {
            e.printStackTrace();
            return "500";
        }
    }

    public List<Client> searchClients(String token, String name) {
        String sql = "http://192.168.0.2:49161/api/Client/GetName/"+name;

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Client> listClients = new ArrayList<Client>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }


                json = response.toString();
                if(!json.toString().equals("false")) {
                    if (json.toString().equals("[]")) {
                        return listClients;
                    } else {
                        JSONArray jsonArr = null;
                        jsonArr = new JSONArray(json);

                        for (int i = 0; i < jsonArr.length(); i++) {
                            JSONObject jsonObject = jsonArr.getJSONObject(i);
                            if (!jsonObject.optString("NameCompany").equals("null")) {
                                listClients.add(new Client(Integer.parseInt(jsonObject.optString("IDClient")), jsonObject.optString("Name"), jsonObject.optString("FirstName"),
                                        jsonObject.optString("SecondName"), jsonObject.optString("Email"), jsonObject.optString("Phone"), jsonObject.optString("CellPhone")
                                        , jsonObject.optString("Address"), jsonObject.optString("NameCompany"), jsonObject.optString("Code")));
                            } else {
                                listClients.add(new Client(Integer.parseInt(jsonObject.optString("IDClient")), jsonObject.optString("Name"), jsonObject.optString("FirstName"),
                                        jsonObject.optString("SecondName"), jsonObject.optString("Email"), jsonObject.optString("Phone"), jsonObject.optString("CellPhone")
                                        , jsonObject.optString("Address"), jsonObject.optString("N/D"), jsonObject.optString("Code")));
                            }
                        }
                        return listClients;
                    }
                }
            }else if (responseCode == 401){
                return listClients;
            }else {
                return listClients;
            }

        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listClients;
        } catch (IOException e) {
            e.printStackTrace();
            return listClients;
        } catch (JSONException e) {
            e.printStackTrace();
            return listClients;
        }
        return listClients;
    }
    public List<Invoice> getAllInvoices(String token) {
        String sql = "http://192.168.0.2:49161/api/Invoice/GetInvoicesAllSales";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Invoice> listInvoices = new ArrayList<Invoice>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    if(jsonObject.optString("Rode")=="null"){
                        String LimitDate = jsonObject.optString("LimitDate");
                        String Limit[] = LimitDate.split("T");
                        String CurrentDate = jsonObject.optString("CurrentDate");
                        String Current[] = CurrentDate.split("T");
                        listInvoices.add(new Invoice(Long.parseLong(jsonObject.optString("IDInvoice")), Limit[0].toString(), Current[0].toString(),
                                jsonObject.optString("Code"), Double.parseDouble(jsonObject.optString("Total")), jsonObject.optString("State"),
                                jsonObject.optString("Name") + " " + jsonObject.optString("FirstName") + " " + jsonObject.optString("SecondName"), jsonObject.optString("NameCompany"),
                                0.0));
                    }else {
                        String LimitDate = jsonObject.optString("LimitDate");
                        String Limit[] = LimitDate.split("T");
                        String CurrentDate = jsonObject.optString("CurrentDate");
                        String Current[] = CurrentDate.split("T");
                        listInvoices.add(new Invoice(Long.parseLong(jsonObject.optString("IDInvoice")), Limit[0].toString(), Current[0].toString(),
                                jsonObject.optString("Code"), Double.parseDouble(jsonObject.optString("Total"))-Double.parseDouble(jsonObject.optString("Rode")), jsonObject.optString("State"),
                                jsonObject.optString("Name") + " " + jsonObject.optString("FirstName") + " " + jsonObject.optString("SecondName"), jsonObject.optString("NameCompany"),
                                Double.parseDouble(jsonObject.optString("Rode"))));
                    }
                }
                return listInvoices;
            }else {
                return listInvoices;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listInvoices;
        } catch (IOException e) {
            e.printStackTrace();
            return listInvoices;
        } catch (JSONException e) {
            e.printStackTrace();
            return listInvoices;
        }
    }
    public List<Invoice> getAllInvoicesExpired(String token) {
        String sql = "http://192.168.0.2:49161/api/Invoice/GetInvoicesAllSalesExpired";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Invoice> listInvoices = new ArrayList<Invoice>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    if(jsonObject.optString("Rode")=="null"){
                        String LimitDate = jsonObject.optString("LimitDate");
                        String Limit[] = LimitDate.split("T");
                        String CurrentDate = jsonObject.optString("CurrentDate");
                        String Current[] = CurrentDate.split("T");
                        listInvoices.add(new Invoice(Long.parseLong(jsonObject.optString("IDInvoice")), Limit[0].toString(), Current[0].toString(),
                                jsonObject.optString("Code"), Double.parseDouble(jsonObject.optString("Total")), jsonObject.optString("State"),
                                jsonObject.optString("Name") + " " + jsonObject.optString("FirstName") + " " + jsonObject.optString("SecondName"), jsonObject.optString("NameCompany"),
                                0.0));
                    }else {
                        String LimitDate = jsonObject.optString("LimitDate");
                        String Limit[] = LimitDate.split("T");
                        String CurrentDate = jsonObject.optString("CurrentDate");
                        String Current[] = CurrentDate.split("T");
                        listInvoices.add(new Invoice(Long.parseLong(jsonObject.optString("IDInvoice")), Limit[0].toString(), Current[0].toString(),
                                jsonObject.optString("Code"), Double.parseDouble(jsonObject.optString("Total"))-Double.parseDouble(jsonObject.optString("Rode")), jsonObject.optString("State"),
                                jsonObject.optString("Name") + " " + jsonObject.optString("FirstName") + " " + jsonObject.optString("SecondName"), jsonObject.optString("NameCompany"),
                                Double.parseDouble(jsonObject.optString("Rode"))));
                    }
                }
                return listInvoices;
            }else {
                return listInvoices;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listInvoices;
        } catch (IOException e) {
            e.printStackTrace();
            return listInvoices;
        } catch (JSONException e) {
            e.printStackTrace();
            return listInvoices;
        }
    }
    public List<Product> getAllProducts(String token) {
        String sql = "http://192.168.0.2:49161/api/Product";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Product> listProducts = new ArrayList<Product>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    if(jsonObject.optString("Tax").toString().equals("null")){
                        listProducts.add(new Product(Integer.parseInt(jsonObject.optString("IDProduct")), jsonObject.optString("Name"), jsonObject.optString("Code"),
                                jsonObject.optString("State"), jsonObject.optString("Description"), Double.parseDouble(jsonObject.optString("Price")), 0.0,
                                Integer.parseInt(jsonObject.optString("IdProvider")), 0, 0.0));
                    }else {
                        listProducts.add(new Product(Integer.parseInt(jsonObject.optString("IDProduct")), jsonObject.optString("Name"), jsonObject.optString("Code"),
                                jsonObject.optString("State"), jsonObject.optString("Description"), Double.parseDouble(jsonObject.optString("Price")), Double.parseDouble(jsonObject.optString("Tax")),
                                Integer.parseInt(jsonObject.optString("IdProvider")), 0, 0.0));
                    }
                }
                return listProducts;
            }else {
                return listProducts;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listProducts;
        } catch (IOException e) {
            e.printStackTrace();
            return listProducts;
        } catch (JSONException e) {
            e.printStackTrace();
            return listProducts;
        }
    }
    public String getDetail(String id, String token) {
        String sql = "http://192.168.0.2:49161/api/Detail/"+id;

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if (!json.equals("false")) {
                    return json;
                } else {
                    return "false";
                }
            }else {
                return "false";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "false";
        } catch (IOException e) {
            e.printStackTrace();
            return "false";
        }
    }
    public String getCode(String token) {
        String sql = "http://192.168.0.2:49161/api/Invoice/GetCode";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;

        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if (!json.equals("false")) {
                    return json;
                } else {
                    return "false";
                }
            }else {
                return "false";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "false";
        } catch (IOException e) {
            e.printStackTrace();
            return "false";
        }
    }
    public String insertInvoices(String LimitDate, String Code, int Discount, Double Total, Boolean State, int IdClient, int IdProvider, long IdDetail, String token) {
        String sql = "http://192.168.0.2:49161/api/Invoice";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        DecimalFormat df = new DecimalFormat("#.00");
        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("LimitDate", LimitDate);
            params.put("Code", Code);
            params.put("Discount", Discount);
            params.put("Total", Total);
            params.put("State", State);
            params.put("IdClient", IdClient);
            params.put("IdProvider", IdProvider);
            params.put("IdDetail", IdDetail);

            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if(json.toString().equals("200")){
                    return "200";
                }else  if(json.toString().equals("501")){
                    return "501";
                }else {
                    return "500";
                }
            }else {
                return "500";
            }

        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "500";
        } catch (IOException e) {
            e.printStackTrace();
            return "500";
        }
    }
    public String insertSales(String Code, int Quantity, Double Total, int IdProduct, long IdDetails, String token) {
        String sql = "http://192.168.0.2:49161/api/Sale";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        DecimalFormat df = new DecimalFormat("#.00");
        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("Code", Code);
            params.put("Quantity", Quantity);
            params.put("Total", Total);
            params.put("IdProduct", IdProduct);
            params.put("IdDetails", IdDetails);

            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if(json.toString().equals("200")){
                    return "200";
                }else {
                    return "500";
                }
            }else {
                return "500";
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "500";
        } catch (IOException e) {
            e.printStackTrace();
            return "500";
        }
    }
    public List<Account> getAllAccounts(String token) {
        String sql = "http://192.168.0.2:49161/api/Accounts";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Account> listAccounts = new ArrayList<Account>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    listAccounts.add(new Account(Integer.parseInt(jsonObject.optString("IDAccount")),jsonObject.optString("Name")));
                }
                return listAccounts;
            }else {
                return listAccounts;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listAccounts;
        } catch (IOException e) {
            e.printStackTrace();
            return listAccounts;
        } catch (JSONException e) {
            e.printStackTrace();
            return listAccounts;
        }
    }
    public List<Category> getAllCategorys(String token) {
        String sql = "http://192.168.0.2:49161/api/Categories";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<Category> listCategorys = new ArrayList<Category>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    listCategorys.add(new Category(Integer.parseInt(jsonObject.optString("IDCategory")),jsonObject.optString("Name")));
                }
                return listCategorys;
            }else {
                return listCategorys;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listCategorys;
        } catch (IOException e) {
            e.printStackTrace();
            return listCategorys;
        } catch (JSONException e) {
            e.printStackTrace();
            return listCategorys;
        }
    }
    public List<SubCategory> getAllSubCategorys(int id, String token) {
        String sql = "http://192.168.0.2:49161/api/SubCategories/" + id;

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        List<SubCategory> listSubCategorys = new ArrayList<SubCategory>();
        try {
            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                JSONArray jsonArr = null;
                jsonArr = new JSONArray(json);

                for (int i = 0; i < jsonArr.length(); i++) {
                    JSONObject jsonObject = jsonArr.getJSONObject(i);
                    listSubCategorys.add(new SubCategory(Integer.parseInt(jsonObject.optString("IDSubCategory")),jsonObject.optString("Name")));
                }
                return listSubCategorys;
            }else if (responseCode == 401){
                return listSubCategorys;
            }else {
                return listSubCategorys;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return listSubCategorys;
        } catch (IOException e) {
            e.printStackTrace();
            return listSubCategorys;
        } catch (JSONException e) {
            e.printStackTrace();
            return listSubCategorys;
        }
    }
    public String insertAssetsLiabilities(String CurrentDate, String Code, Double Rode, Boolean Type, String Description, String Name,
                                          Boolean State, Long IdInvoice, int IdAccount, int IdSubCategory, int IdUser, String token) {
        String sql = "http://192.168.0.2:49161/api/AssetLiability";

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        URL url = null;
        HttpURLConnection conn;
        DecimalFormat df = new DecimalFormat("#.00");
        try {
            Map<String, Object> params = new LinkedHashMap<>();
            params.put("CurrentDate", CurrentDate);
            params.put("Code", Code);
            params.put("Rode", Rode);
            params.put("Type", Type);
            params.put("Description", Description);
            params.put("Name", Name);
            params.put("State", State);
            params.put("IdInvoice",IdInvoice);
            params.put("IdAccount", IdAccount);
            params.put("IdSubCategory", IdSubCategory);
            params.put("IdUser", IdUser);

            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0) postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()), "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");

            url = new URL(sql);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            conn.setRequestProperty("Authorization", "Bearer " + token);

            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);

            int responseCode = conn.getResponseCode();
            //String responseMsg = connection.getResponseMessage();

            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));

                String inputLine;

                StringBuffer response = new StringBuffer();

                String json = "";

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                json = response.toString();

                if(json.toString().equals("200")){
                    return "200";
                }else {
                    return "500";
                }
            }else {
                return "500";
            }

        } catch (MalformedURLException e) {
            e.printStackTrace();
            return "500";
        } catch (IOException e) {
            e.printStackTrace();
            return "500";
        }
    }
}
