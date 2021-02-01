import list.ChallengeList;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class Tests {
    @Test
    public void firstTest() {
        challenges.Test test = new challenges.Test();
        try {
            test = (challenges.Test)ChallengeList.getNext();
            assertEquals(test.toString(), "This is a test");
        }
        catch (Exception ex) {

        }
    }
}
