/*
* To change this license header, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
package com.gen.ejbpattern.model;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class dbConnection {
    public void connection(){
    try{
    String url = "jdbc:mysql://localhost:3306/projetjee";
    String user = "root";
    String passwd ="root";
    Connection conn = DriverManager.getConnection(url, user, passwd);
    }catch(Exception e){
    e.printStackTrace();
    }
}


// Add business logic below. (Right-click in editor and choose
// "Insert Code > Add Business Method")
}
