package pack1;

public interface IProduct {
    void setName(String n);
    String getName();
    void setPrice(double p)throws PriceException;
    double getPrice();
}
