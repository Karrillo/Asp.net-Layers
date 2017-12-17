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
    /**
     *metodo vacio constructor de Client
     */
    public Client() {
    }
    /**
     * @param IDClient
     * @param name
     * @param firstName
     * @param secondName
     * @param email
     * @param phone
     * @param cellPhone
     * @param address
     * @param nameCompany
     * @param code
     * metodo constructor de Client
     */
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
    /**
     * @return IDClient
     */
    public int getIDClient() {
        return IDClient;
    }
    /**
     * @param IDClient
     */
    public void setIDClient(int IDClient) {
        this.IDClient = IDClient;
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
     * @return FirstName
     */
    public String getFirstName() {
        return FirstName;
    }
    /**
     * @param firstName
     */
    public void setFirstName(String firstName) {
        FirstName = firstName;
    }
    /**
     * @return SecondName
     */
    public String getSecondName() {
        return SecondName;
    }
    /**
     * @param secondName
     */
    public void setSecondName(String secondName) {
        SecondName = secondName;
    }
    /**
     * @return Email
     */
    public String getEmail() {
        return Email;
    }
    /**
     * @param email
     */
    public void setEmail(String email) {
        Email = email;
    }
    /**
     * @return Phone
     */
    public String getPhone() {
        return Phone;
    }
    /**
     * @param phone
     */
    public void setPhone(String phone) {
        Phone = phone;
    }
    /**
     * @return CellPhone
     */
    public String getCellPhone() {
        return CellPhone;
    }
    /**
     * @param cellPhone
     */
    public void setCellPhone(String cellPhone) {
        CellPhone = cellPhone;
    }
    /**
     * @return Address
     */
    public String getAddress() {
        return Address;
    }
    /**
     * @param address
     */
    public void setAddress(String address) {
        Address = address;
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
     * @return Client
     */
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
