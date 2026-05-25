abstract class Product {
    private String name;
    private double price;
    //static int id;
    static int counter;
    static double sum;

    static {
        counter = 0;
        sum = 0;
    }

    Product() {
        name = null;
        price = 0.0;
        counter++;
        sum += price;
    }

    Product(String n, double p) {
        name = n;
        price = p;
        counter++;
        sum += price;
    }

    void setName(String n) {
        name = n;
    }

    String getName() {
        return name;
    }

    void setPrice(double p) {
        price = p;
    }

    double getPrice() {
        return price;
    }

    public String toString() {
        return "Товар: " + name + ", Цена: " + price;
    }

    static void avg() {
        System.out.println(sum / counter);
    }
}
