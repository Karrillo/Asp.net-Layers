package com.example.carrillo.santamarta;

import java.text.DecimalFormat;

/**
 * Created by joser on 15/11/2017.
 */

public class Invoice {
    public long IDInvoice;
    public String LimitDate;
    public String CurrentDate;
    public String Code;
    public double Total;
    public String State;
    public String Name;
    public String NameCompany;
    public double Rode;

    public Invoice() {
    }

    public Invoice(long IDInvoice, String limitDate, String currentDate, String code, double total, String state, String name, String nameCompany, double rode) {
        this.IDInvoice = IDInvoice;
        LimitDate = limitDate;
        CurrentDate = currentDate;
        Code = code;
        Total = total;
        State = state;
        Name = name;
        NameCompany = nameCompany;
        Rode = rode;
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

    public String getCurrentDate() {
        return CurrentDate;
    }

    public void setCurrentDate(String currentDate) {
        CurrentDate = currentDate;
    }

    public String getCode() {
        return Code;
    }

    public void setCode(String code) {
        Code = code;
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

    public double getRode() {
        return Rode;
    }

    public void setRode(double rode) {
        Rode = rode;
    }

    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("#.00");
        if(Rode==0 && Total==0){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + Rode + '\n' +
                            "Total: " + Total;
        }else if(Rode>0 && Total>0){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + df.format(Rode) + '\n' +
                            "Total: " + df.format(Total);
        }else if(Rode>0 && Total==0){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + df.format(Rode) + '\n' +
                            "Total: " + Total;
        }else {
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + Rode + '\n' +
                            "Total: " + df.format(Total);
        }
    }
}
