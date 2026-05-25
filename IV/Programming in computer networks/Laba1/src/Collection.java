public class Collection {
    private Product [] product;
    int count(){
        if(product==null)
            return 0;
        return product.length;
    }
    void add(Product p)
    {
        Product[] newProduct=new Product[count()+1];
        for(int i=0;i<count();i++)
            newProduct[i]=product[i];
        newProduct[count()]=p;
        product=newProduct;
    }
    void sort(){
        Product temp;
        for (int i = 0; i < product.length - 1; i++)
        {
            for (int j = i + 1; j < product.length; j++)
            {
                if (product[i].getPrice() > product[j].getPrice())
                {

                    temp = product[i];
                    product[i] = product[j];
                    product[j] = temp;
                }
            }
        }

    }
    Product getProduct(int index){
        return product[index];
    }

     public void print(){
        for (Product i:product){
             System.out.println(i);
        }
    }


}
