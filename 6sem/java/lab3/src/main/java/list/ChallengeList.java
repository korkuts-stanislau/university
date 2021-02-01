package list;

import challenges.Challenge;

public final class ChallengeList {
    private static Node<Challenge> startNode;
    private static Node<Challenge> currentNode;

    private ChallengeList() {
        startNode = new Node<>(null);
        currentNode = startNode;
    }

    public static void add(Challenge value) {
        Node<Challenge> cur = startNode;
        while (cur.hasNext()) {
            cur = cur.getNext();
        }
        cur.setNext(new Node<>(value));
    }

    public static boolean hasNext() {
        return currentNode.hasNext();
    }

    public static Challenge getNext() throws Exception {
        if(currentNode.hasNext()) {
            currentNode = currentNode.getNext();
            return currentNode.getValue();
        }
        else {
            throw new Exception("У списка нет следующего значения");
        }
    }

    public static void refresh() {
        currentNode = startNode;
    }
}
