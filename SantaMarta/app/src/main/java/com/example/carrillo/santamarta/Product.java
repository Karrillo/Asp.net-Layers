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

    public Product() {
    }

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

    public int getIDProduct() {
        return IDProduct;
    }

    public void setIDProduct(int IDProduct) {
        this.IDProduct = IDProduct;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getCode() {
        return Code;
    }

    public void setCode(String code) {
        Code = code;
    }

    public String getState() {
        return State;
    }

    public void setState(String state) {
        State = state;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public double getPrice() {
        return Price;
    }

    public void setPrice(double price) {
        Price = price;
    }

    public double getTax() {
        return Tax;
    }

    public void setTax(double tax) {
        Tax = tax;
    }

    public int getIdProvider() {
        return IdProvider;
    }

    public void setIdProvider(int idProvider) {
        IdProvider = idProvider;
    }

    public int getQuantity() {
        return Quantity;
    }

    public void setQuantity(int quantity) {
        Quantity = quantity;
    }

    public double getTotal() {
        return Total;
    }

    public void setTotal(double total) {
        Total = total;
    }

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
