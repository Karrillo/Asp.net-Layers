package com.example.carrillo.santamarta;

/**
 * Created by joser on 27/11/2017.
 */

public class Category {
    public int id;
    public String Name;

    public Category() {
    }

    public Category(int id, String name) {
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
                "Nombre de Categoria:" + Name + '\n';
    }
}
