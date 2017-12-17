package com.example.carrillo.santamarta;
/**
 * Created by joser on 27/11/2017.
 */
public class Category {
    public int id;
    public String Name;
    /**
     *metodo vacio constructor de Category
     */
    public Category() {
    }
    /**
     * @param id
     * @param name
     * metodo constructor de Category
     */
    public Category(int id, String name) {
        this.id = id;
        Name = name;
    }
    /**
     * @return id
     */
    public int getId() {
        return id;
    }
    /**
     * @param id
     */
    public void setId(int id) {
        this.id = id;
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
     * @return Category
     */
    @Override
    public String toString() {
        return
                "Nombre de Categoria: " + Name + '\n';
    }
}
