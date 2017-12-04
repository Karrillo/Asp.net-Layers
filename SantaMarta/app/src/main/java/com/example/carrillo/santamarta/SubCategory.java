package com.example.carrillo.santamarta;

/**
 * Created by joser on 27/11/2017.
 */

public class SubCategory {
    public int id;
    public String Name;

    public SubCategory() {
    }

    public SubCategory(int id, String name) {
        this.id = id;
        Name = name;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    @Override
    public String toString() {
        return
                "Nombre de Subcategoria: " + Name + '\n';
    }
}