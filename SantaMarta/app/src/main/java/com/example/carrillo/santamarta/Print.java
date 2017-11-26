package com.example.carrillo.santamarta;

/**
 * Created by joser on 25/11/2017.
 */

public class Print {
    public String curent;
    public String limit;
    public String numInvoice;
    public String discount;
    public String total;
    public Print() {
    }

    public Print(String curent, String limit, String numInvoice, String discount, String total) {
        this.curent = curent;
        this.limit = limit;
        this.numInvoice = numInvoice;
        this.discount = discount;
        this.total = total;
    }

    public String getCurent() {
        return curent;
    }

    public void setCurent(String curent) {
        this.curent = curent;
    }

    public String getLimit() {
        return limit;
    }

    public void setLimit(String limit) {
        this.limit = limit;
    }

    public String getNumInvoice() {
        return numInvoice;
    }

    public void setNumInvoice(String numInvoice) {
        this.numInvoice = numInvoice;
    }

    public String getDiscount() {
        return discount;
    }

    public void setDiscount(String discount) {
        this.discount = discount;
    }

    public String getTotal() {
        return total;
    }

    public void setTotal(String total) {
        this.total = total;
    }
}
