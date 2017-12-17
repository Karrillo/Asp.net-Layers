package com.example.carrillo.santamarta;

import java.text.DecimalFormat;

/**
 * Created by joser on 18/11/2017.
 */
public class Product {
    public int IDProduct ;
    public String Name ;
    public String Code ;
    public String State ;
    public String Description;
    public double Price ;
    public double Tax ;
    public int IdProvider ;
    public int Quantity;
    public double Total;
    /**
     *metodo vacio constructor de Product
     */
    public Product() {
    }
    /**
     * @param IDProduct
     * @param name
     * @param code
     * @param state
     * @param description
     * @param price
     * @param tax
     * @param idProvider
     * @param quantity
     * @param total
     * metodo constructor de Product
     */
    public Product(int IDProduct, String name, String code, String state, String description, double price, double tax, int idProvider, int quantity, double total) {
        this.IDProduct = IDProduct;
        Name = name;
        Code = code;
        State = state;
        Description = description;
        Price = price;
        Tax = tax;
        IdProvider = idProvider;
        Quantity = quantity;
        Total = total;
    }
    /**
     * @return IDProduct
     */
    public int getIDProduct() {
        return IDProduct;
    }
    /**
     * @param IDProduct
     */
    public void setIDProduct(int IDProduct) {
        this.IDProduct = IDProduct;
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
     * @return Description
     */
    public String getDescription() {
        return Description;
    }
    /**
     * @param description
     */
    public void setDescription(String description) {
        Description = description;
    }
    /**
     * @return Price
     */
    public double getPrice() {
        return Price;
    }
    /**
     * @param price
     */
    public void setPrice(double price) {
        Price = price;
    }
    /**
     * @return Tax
     */
    public double getTax() {
        return Tax;
    }
    /**
     * @param tax
     */
    public void setTax(double tax) {
        Tax = tax;
    }
    /**
     * @return IdProvider
     */
    public int getIdProvider() {
        return IdProvider;
    }
    /**
     * @param idProvider
     */
    public void setIdProvider(int idProvider) {
        IdProvider = idProvider;
    }
    /**
     * @return Quantity
     */
    public int getQuantity() {
        return Quantity;
    }
    /**
     * @param quantity
     */
    public void setQuantity(int quantity) {
        Quantity = quantity;
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
     * @return Product
     */
    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("#.00");
        if(Quantity<=0){
            return
                    "Nombre: " + Name + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Precio: " + Price + '\n' +
                            "Impuesto: " + Tax;
        }else {
            return
                    "Nombre: " + Name + '\n' +
                            "Codigo: " + Code + '\n' +
                            "Precio: " + Price + '\n' +
                            "Impuesto: " + Tax + '\n' +
                            "Cantidad: " + Quantity + '\n' +
                            "Total: " + df.format(Total);
        }
    }
}
