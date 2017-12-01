package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by joser on 27/11/2017.
 */

public class AssetsliabilitiesSubCategory extends AppCompatActivity {

    private ListView list;

    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private List<SubCategory> listSubCategorys;
    private SubCategory subcategory;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_assetsliabilities_subcategory);

        list = (ListView) findViewById(R.id.list_subcategorys);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        listSubCategorys = contextdb.getAllSubCategorys(AssetsliabilitiesActivity.select_Category(),token);
        display(listSubCategorys);
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        list.setOnItemClickListener(new android.widget.AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(position>=0){
                    subcategory = listSubCategorys.get(position);
                    AssetsliabilitiesActivity.display_subCategory(subcategory);
                    finish();
                }
            }
        });
    }

    public void display(List<SubCategory> SubCategorys) {
        if (SubCategorys.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Categorias no encontradas");
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            ArrayAdapter<SubCategory> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, SubCategorys);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        }
    }
}
