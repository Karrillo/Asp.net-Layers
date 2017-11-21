package com.example.carrillo.santamarta;

/**
 * Created by joser on 15/11/2017.
 */

public class Invoice {
    public long IDInvoice;
    public String LimitDate;
    public String Code;
    public int Discount;
    public double Total;
    public String State;
    public int IdClient;
    public int IdProvider;
    public long IdDetail;
    public String Name;
    public String NameCompany;

    public Invoice() {
    }

    public Invoice(long IDInvoice, String limitDate, String code, int discount, double total, String state, int idClient, int idProvider, long idDetail, String name, String nameCompany) {
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

    public long getIDInvoice() {
        return IDInvoice;
    }

    public void setIDInvoice(long IDInvoice) {
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

    public int getDiscount() {
        return Discount;
    }

    public void setDiscount(int discount) {
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

    public long getIdDetail() {
        return IdDetail;
    }

    public void setIdDetail(long idDetail) {
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
