/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.ejbpattern.model;

import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

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
        co.connection();
    }
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
