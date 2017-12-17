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
    /**
     *metodo vacio constructor de Invoice
     */
    public Invoice() {
    }
    /**
     * @param IDInvoice
     * @param limitDate
     * @param currentDate
     * @param code
     * @param total
     * @param state
     * @param name
     * @param nameCompany
     * @param rode
     * metodo constructor de Invoice
     */
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
    /**
     * @return IDInvoice
     */
    public long getIDInvoice() {
        return IDInvoice;
    }
    /**
     * @param IDInvoice
     */
    public void setIDInvoice(long IDInvoice) {
        this.IDInvoice = IDInvoice;
    }
    /**
     * @return LimitDate
     */
    public String getLimitDate() {
        return LimitDate;
    }
    /**
     * @param limitDate
     */
    public void setLimitDate(String limitDate) {
        LimitDate = limitDate;
    }
    /**
     * @return CurrentDate
     */
    public String getCurrentDate() {
        return CurrentDate;
    }
    /**
     * @param currentDate
     */
    public void setCurrentDate(String currentDate) {
        CurrentDate = currentDate;
    }
    /**
     * @return Code
     */
    public String getCode() {
        return Code;
    }
    /**
     * @param code
     */
    public void setCode(String code) {
        Code = code;
    }
    /**
     * @return Total
     */
    public double getTotal() {
        return Total;
    }
    /**
     * @param total
     */
    public void setTotal(double total) {
        Total = total;
    }
    /**
     * @return State
     */
    public String getState() {
        return State;
    }
    /**
     * @param state
     */
    public void setState(String state) {
        State = state;
    }
    /**
     * @return Name
     */
    public String getName() {
        return Name;
    }
    /**
     * @param name
     */
    public void setName(String name) {
        Name = name;
    }
    /**
     * @return NameCompany
     */
    public String getNameCompany() {
        return NameCompany;
    }
    /**
     * @param nameCompany
     */
    public void setNameCompany(String nameCompany) {
        NameCompany = nameCompany;
    }
    /**
     * @return Rode
     */
    public double getRode() {
        return Rode;
    }
    /**
     * @param rode
     */
    public void setRode(double rode) {
        Rode = rode;
    }
    /**
     * @return Invoice
     */
    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("#.00");
        DecimalFormat dfd = new DecimalFormat("0.00");
        if(Rode<1 && Total<1){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + Rode + '\n' +
                            "Total: " + Total;
        }else if(Rode>0 && Rode<1 && Total>=1){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + dfd.format(Rode) + '\n' +
                            "Total: " + Total;
        }else if(Total>0 && Total<1 && Rode>=1){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + Rode + '\n' +
                            "Total: " + dfd.format(Total);
        }else if(Rode>0 && Rode<1 && Total>0 && Total<1){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + dfd.format(Rode) + '\n' +
                            "Total: " + dfd.format(Total);
        }else if(Rode>=1 && Total>=1){
            return
                    "Nombre de cliente: " + Name + '\n' +
                            "Nombre de compañia: " + NameCompany + '\n' +
                            "Fecha Creación: " + CurrentDate + '\n' +
                            "Fecha limite: " + LimitDate + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Abonado: " + df.format(Rode) + '\n' +
                            "Total: " + df.format(Total);
        }else if(Rode>=1 && Total<1){
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
