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
    /**
     *
     */
    public Print() {
    }
    /**
     * @param curent
     * @param limit
     * @param numInvoice
     * @param discount
     * @param total
     */
    public Print(String curent, String limit, String numInvoice, String discount, String total) {
        this.curent = curent;
        this.limit = limit;
        this.numInvoice = numInvoice;
        this.discount = discount;
        this.total = total;
    }
    /**
     * @return
     */
    public String getCurent() {
        return curent;
    }
    /**
     * @param curent
     */
    public void setCurent(String curent) {
        this.curent = curent;
    }
    /**
     * @return
     */
    public String getLimit() {
        return limit;
    }
    /**
     * @param limit
     */
    public void setLimit(String limit) {
        this.limit = limit;
    }
    /**
     * @return
     */
    public String getNumInvoice() {
        return numInvoice;
    }
    /**
     * @param numInvoice
     */
    public void setNumInvoice(String numInvoice) {
        this.numInvoice = numInvoice;
    }
    /**
     * @return
     */
    public String getDiscount() {
        return discount;
    }
    /**
     * @param discount
     */
    public void setDiscount(String discount) {
        this.discount = discount;
    }
    /**
     * @return
     */
    public String getTotal() {
        return total;
    }
    /**
     * @param total
     */
    public void setTotal(String total) {
        this.total = total;
    }
}
