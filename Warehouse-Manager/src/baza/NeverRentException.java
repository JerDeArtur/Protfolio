package baza;

class NeverRentException extends Exception {

    NeverRentException(String message) {
        super(message);
    }

    @Override
    public String toString() {
        return getMessage();
    }
}
