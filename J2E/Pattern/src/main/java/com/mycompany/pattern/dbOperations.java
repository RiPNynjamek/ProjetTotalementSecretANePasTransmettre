/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import com.mycompany.logger.Logger;
import java.io.IOException;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class dbOperations {
    private dbConnection co = new dbConnection();
    private float tauxConfiance;
    public float searchWord(String message, String key){
        System.out.println("search ");
        List<String> listMots = new ArrayList();
        List<String> motsTrouve = new ArrayList();
        
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
            insertHistory(listMots, key);
        }catch(Exception e){
            try {
                Logger.writeLog(e.getMessage());
            } catch (IOException ex) {
                java.util.logging.Logger.getLogger(dbOperations.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        tauxConfiance = (float) motsTrouve.size() / (float)listMots.size() ;
        tauxConfiance = tauxConfiance * 100;
        
        return tauxConfiance;
        
    }
    
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
    public void insertHistory(List<String> mots, String key) throws SQLException
    {
        Connection connection = co.connection();
        
        try
        {
            String message = "";
            
            for (String mot : mots) {
                message += mot;
                message += " ";
            }
            Timestamp date = new Timestamp(new java.util.Date().getTime());
            
            Statement state = connection.createStatement();
            System.out.println("Test");
            String query = "INSERT INTO HISTORY(DATA, DECRYPTIONKEY, DATE) VALUES('" + message + "', '" + key + "', '" + date + "');";
            state.executeUpdate(query);
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
            try {
                Logger.writeLog(e.getMessage());
            } catch (IOException ex) {
                java.util.logging.Logger.getLogger(dbOperations.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        
    }
}
