package com.example.carrillo.santamarta;

/**
 * Created by joser on 14/10/2017.
 */

public class Client {
    public int IDClient;

    public String Name;

    public String FirstName;

    public String SecondName;

    public String Email;

    public String Phone;

    public String CellPhone;

    public String Address;

    public String NameCompany;

    public String Code;

    public Client() {
    }

    public Client(int IDClient, String name, String firstName, String secondName, String email, String phone, String cellPhone, String address, String nameCompany, String code) {
        this.IDClient = IDClient;
        Name = name;
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        Phone = phone;
        CellPhone = cellPhone;
        Address = address;
        NameCompany = nameCompany;
        Code = code;
    }

    public int getIDClient() {
        return IDClient;
    }

    public void setIDClient(int IDClient) {
        this.IDClient = IDClient;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getSecondName() {
        return SecondName;
    }

    public void setSecondName(String secondName) {
        SecondName = secondName;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public String getPhone() {
        return Phone;
    }

    public void setPhone(String phone) {
        Phone = phone;
    }

    public String getCellPhone() {
        return CellPhone;
    }

    public void setCellPhone(String cellPhone) {
        CellPhone = cellPhone;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }

    public String getNameCompany() {
        return NameCompany;
    }

    public void setNameCompany(String nameCompany) {
        NameCompany = nameCompany;
    }

    public String getCode() {
        return Code;
    }

    public void setCode(String code) {
        Code = code;
    }

    @Override
    public String toString() {
        return
                "Name: " + Name + ' ' + FirstName + ' ' + SecondName + '\n' +
                "Email: " + Email + '\n' +
                "Phone: " + Phone + '\n' +
                "CellPhone: " + CellPhone + '\n' +
                "Address: " + Address + '\n' +
                "NameCompany: " + NameCompany + '\n' +
                "Code: " + Code ;
    }
}
