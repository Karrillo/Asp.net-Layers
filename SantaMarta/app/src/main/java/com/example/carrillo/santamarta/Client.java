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

    public String identification;

    public String NameCompany;

    public Client() {
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

    public String getIdentification() {
        return identification;
    }

    public void setIdentification(String identification) {
        this.identification = identification;
    }

    public String getNameCompany() {
        return NameCompany;
    }

    public void setNameCompany(String nameCompany) {
        NameCompany = nameCompany;
    }

    @Override
    public String toString() {
        return "Client{" +
                "IDClient=" + IDClient +
                ", Name='" + Name + '\'' +
                ", FirstName='" + FirstName + '\'' +
                ", SecondName='" + SecondName + '\'' +
                ", Email='" + Email + '\'' +
                ", Phone='" + Phone + '\'' +
                ", CellPhone='" + CellPhone + '\'' +
                ", Address='" + Address + '\'' +
                ", identification='" + identification + '\'' +
                ", NameCompany='" + NameCompany + '\'' +
                '}';
    }
}
