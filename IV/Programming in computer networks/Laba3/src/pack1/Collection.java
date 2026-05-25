package pack1;


public class Collection<T extends Product> implements {
    private T[] product;

    public int count() {
        if (product == null)
            return 0;
        return product.length;
    }

    public void add(T p) {
        T[] newProduct = (T[]) new Product[count() + 1];

        for (int i = 0; i < count(); i++)
            newProduct[i] = product[i];
        newProduct[count()] = p;
        product = newProduct;
    }

    public void sort() {
        T temp;
        for (int i = 0; i < product.length - 1; i++) {
            for (int j = i + 1; j < product.length; j++) {
                if (product[i].getPrice() > product[j].getPrice()) {

                    temp = product[i];
                    product[i] = product[j];
                    product[j] = temp;
                }
            }
        }

    }

    public T getProduct(int index) {
        return product[index];
    }

    public void print() {
        for (T i : product) {
            System.out.println(i);
        }
    }

    class Iterator {
        int position = -1;

        public boolean hasNext() {
            if (position == product.length - 1) {
                return false;
            } else {
                position++;
                return true;
            }
        }

        public Product next() {

            return product[position];
        }

        public Product previousPosition() {
            return product[position + 1];
        }

        public boolean hasPreviousPosition() {
            if (position >= 0) {
                position--;

                return true;
            } else {

                return false;
            }

        }


    }

    public void reverseIterator() {

        Iterator iterator = new Iterator();
        iterator.position= product.length-1;
        while (iterator.hasPreviousPosition()) {
            Product w = iterator.previousPosition();
            System.out.println(w);
        }


    }

    public void GetPriceInTheInterval(double a, double b) {
        Iterator iterator2 = new Iterator() {
            int position = -1;

            public boolean hasNext() {
                if (position == product.length - 1) {
                    return false;
                } else {
                    position++;
                    return true;
                }
            }

            public Product next() {

                return product[position];
            }

        };
        while (iterator2.hasNext()) {
            Product w = iterator2.next();
            if (w.getPrice() > a && w.getPrice() < b) {
                System.out.println(w);
            }


        }


    }


}
