/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import com.mycompany.logger.Logger;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.logging.Level;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class dbConnection {
    private Connection connection;
    public Connection connection(){
        try{
            String url = "jdbc:mysql://localhost:3306/projetjee";
            String user = "root";
            String passwd ="";
            connection = DriverManager.getConnection(url, user, passwd);
        }catch(Exception e){
            try {
                Logger.writeLog(e.getMessage());
            } catch (IOException ex) {
                java.util.logging.Logger.getLogger(dbConnection.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        return connection;
    }
}
