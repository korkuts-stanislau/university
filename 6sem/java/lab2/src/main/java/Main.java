import ussr.USSR;

import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello world");
        USSR ussr = new USSR();
        ussr.addNewRecord(new GregorianCalendar(1961, Calendar.FEBRUARY, 6).getTime(), "There was nothing this day");
        ussr.addNewRecord(new GregorianCalendar(1945, Calendar.SEPTEMBER, 1).getTime(), "War was ended");
        System.out.println(ussr.getRecordsAscending());
    }
}
