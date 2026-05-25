package pack1;

public class PriceException extends Exception{
    public double price;
    PriceException(double p) {
        price=p;

    }
    public String toString(){
        return "Цена не может быть отрицательной: "+price;
    }


}
