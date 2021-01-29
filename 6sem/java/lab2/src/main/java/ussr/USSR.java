package ussr;

import java.util.*;

public class USSR {
    private class Record implements Comparable<Record> {
        protected Record(Date date, String description) {
            recordDate = date;
            recordDescription = description;
        }

        Date recordDate;
        String recordDescription;

        public Date getRecordDate() {
            return recordDate;
        }

        public void setRecordDate(Date recordDate) {
            this.recordDate = recordDate;
        }

        public String getRecordDescription() {
            return recordDescription;
        }

        public void setRecordDescription(String recordDescription) {
            this.recordDescription = recordDescription;
        }

        @Override
        public int compareTo(Record o) {
            return recordDate.compareTo(o.recordDate);
        }
    }

    public USSR() {
        records = new ArrayList<>();
    }

    private List<Record> records;

    public void addNewRecord(Date date, String description) {
        records.add(new Record(date, description));
    }

    public List<String> getRecordsAscending() {
        Collections.sort(records);
        List<String> recs = new ArrayList<>();
        for (Record record :
                records) {
            recs.add(record.recordDate.toString() + ": " + record.recordDescription);
        }
        return recs;
    }
}