package challenges;

import list.ChallengeList;

public abstract class Challenge {
    public Challenge() {
        ChallengeList.add(this);
    }
}
