/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern.model;

import java.sql.Statement;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import java.sql.ResultSet;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class dbOperations {
    
    public void searchWord(String message){
        System.out.println("search ");
        dbConnection co = new dbConnection();
        Statement state = co.connection();
        String query ="SELECT * FROM dico";
        String colone = "mot";
        try{
            ResultSet result = state.executeQuery(query);
            while(result.next()){
                System.out.println(result.getString(colone));
            }
            
        }catch(Exception e){
            e.printStackTrace();
        }
        
        
    }
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
