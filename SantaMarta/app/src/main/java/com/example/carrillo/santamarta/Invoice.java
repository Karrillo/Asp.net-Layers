package com.example.carrillo.santamarta;

/**
 * Created by joser on 15/11/2017.
 */

public class Invoice {
    public int IDInvoice;
    public String LimitDate;
    public String Code;
    public double Discount;
    public double Total;
    public String State;
    public int IdClient;
    public int IdProvider;
    public int IdDetail;
    public String Name;
    public String NameCompany;
    public Invoice() {
    }

    public Invoice(int IDInvoice, String limitDate, String code, double discount, double total, String state, int idClient, int idProvider, int idDetail, String name, String nameCompany) {
        this.IDInvoice = IDInvoice;
        LimitDate = limitDate;
        Code = code;
        Discount = discount;
        Total = total;
        State = state;
        IdClient = idClient;
        IdProvider = idProvider;
        IdDetail = idDetail;
        Name = name;
        NameCompany = nameCompany;
    }

    public int getIDInvoice() {
        return IDInvoice;
    }

    public void setIDInvoice(int IDInvoice) {
        this.IDInvoice = IDInvoice;
    }

    public String getLimitDate() {
        return LimitDate;
    }

    public void setLimitDate(String limitDate) {
        LimitDate = limitDate;
    }

    public String getCode() {
        return Code;
    }

    public void setCode(String code) {
        Code = code;
    }

    public double getDiscount() {
        return Discount;
    }

    public void setDiscount(double discount) {
        Discount = discount;
    }

    public double getTotal() {
        return Total;
    }

    public void setTotal(double total) {
        Total = total;
    }

    public String getState() {
        return State;
    }

    public void setState(String state) {
        State = state;
    }

    public int getIdClient() {
        return IdClient;
    }

    public void setIdClient(int idClient) {
        IdClient = idClient;
    }

    public int getIdProvider() {
        return IdProvider;
    }

    public void setIdProvider(int idProvider) {
        IdProvider = idProvider;
    }

    public int getIdDetail() {
        return IdDetail;
    }

    public void setIdDetail(int idDetail) {
        IdDetail = idDetail;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getNameCompany() {
        return NameCompany;
    }

    public void setNameCompany(String nameCompany) {
        NameCompany = nameCompany;
    }

    @Override
    public String toString() {
        return
                "Nombre de cliente: " + Name + '\n' +
                "Nombre de compañia: " + NameCompany + '\n' +
                "Fecha limite: " + LimitDate + '\n' +
                "Codigo: " + Code + '\n' +
                "Total: " + Total ;
    }
}
