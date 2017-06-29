/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gen.wsgen;

import com.mycompany.connection.Connect;
import com.mycompany.pattern.Route;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Pattern;
import javax.ejb.EJB;
import javax.jws.Oneway;
import javax.jws.WebMethod;
import javax.jws.WebService;

/**
 *
 * @author Cyril
 */
@WebService(serviceName = "wsGen")
public class wsGen {
    
    @EJB
    private Connect ejbRef;// Add business logic below. (Right-click in editor and choose
    @EJB
    private Route ejbRef2;
    // "Web Service > Add Operation"

    @WebMethod(operationName = "send")
    @Oneway
    public void send() {
        
    }
    
    @WebMethod(operationName = "receive")
    @Oneway
    public void receive() {
        Thread t = new Thread(){
            public void run(){
                ejbRef.receive();
            }
        };
        t.start();
        
        
        try {
            Thread.sleep(3000);
        } catch (InterruptedException ex) {
            Logger.getLogger(wsGen.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        Thread t2 = new Thread(){
            public void run(){
                ejbRef2.compare();
            }
        };
        t2.start();
    }
   
}
