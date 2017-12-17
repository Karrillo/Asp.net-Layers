package com.example.carrillo.santamarta;

/**
 * Created by joser on 27/11/2017.
 */
public class SubCategory {
    public int id;
    public String Name;
    /**
     *metodo vacio constructor de SubCategory
     */
    public SubCategory() {
    }
    /**
     * @param id
     * @param name
     * metodo constructor de SubCategory
     */
    public SubCategory(int id, String name) {
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
     * @return SubCategory
     */
    @Override
    public String toString() {
        return
                "Nombre de Subcategoria: " + Name + '\n';
    }
}
