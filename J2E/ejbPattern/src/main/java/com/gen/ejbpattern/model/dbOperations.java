/*
* To change this license header, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
package com.gen.ejbpattern.model;

import java.sql.Connection;
import java.sql.Statement;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import java.sql.ResultSet;
import java.util.ArrayList;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class dbOperations {
    private float tauxConfiance;
    public float searchWord(String message){
        System.out.println("search ");
        List<String> listMots = new ArrayList();
        List<String> motsTrouve = new ArrayList();
        dbConnection co = new dbConnection();
        Connection connection = co.connection();
        try{
            Statement state = connection.createStatement();
            String query ="SELECT mot FROM dico";
            String colone = "mot";
            System.out.println("query :");
            ResultSet result = state.executeQuery(query);
            String[] tableMessage = message.split(" ");
            for (int i=0; i<tableMessage.length; i++){
                listMots.add(tableMessage[i]);
            }
            while(result.next()){
                String word = result.getString(colone);
                word = word.replaceAll("\\n", "");
                for (int i=0; i<listMots.size(); i++){
                    if(listMots.get(i).equals(word)){
                        System.out.println("contient " + word);
                        motsTrouve.add(word);
                    }
                }
            }
            
            
            
        }catch(Exception e){
            e.printStackTrace();
        }
        tauxConfiance = (float) motsTrouve.size() / (float)listMots.size() ;
        tauxConfiance = tauxConfiance * 100;
        return tauxConfiance;
    }
    
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
