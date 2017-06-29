/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.logger;

import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;

/**
 *
 * @author cyril
 */
@Stateless
@LocalBean
public class Logger {

    private static final String path = "C:/logFile.txt";
    public static void writeLog(String s) throws IOException {
        write(path, s);
    }

    private static void write(String path, String s) throws IOException {
        TimeZone tz = TimeZone.getTimeZone("Europe/Paris"); // or PST, MID, etc ...
         Date now = new Date();
         DateFormat df = new SimpleDateFormat ("yyyy.mm.dd hh:mm:ss ");
         df.setTimeZone(tz);
         String currentTime = df.format(now);
         
         FileWriter aWriter = new FileWriter(path,true);
         aWriter.write(currentTime+ " " + s + "\n");
         aWriter.flush();
         aWriter.close();
    }
}
