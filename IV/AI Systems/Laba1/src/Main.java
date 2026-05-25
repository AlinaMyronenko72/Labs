import java.util.ArrayList;
import java.util.Scanner;


public class Main {
    static ArrayList<String> object1;
    static ArrayList<String> object2;
    static ArrayList<String> qualities;
    static Scanner scanner = new Scanner(System.in);
    public static void main(String[] args) {
        object1=new ArrayList<>();
        object2=new ArrayList<>();
        scanner = new Scanner(System.in);
        enterStartData();
        while (true) {
            System.out.println("Чи хотіли би ви продовжити?");
            String answer = scanner.nextLine();
            if(answer.equals("ні"))break;
            qualities=new ArrayList<>();
            printQualities();
            askQualities();
            checkQualities();
        }
    }

    private static void checkQualities() {
        int match1=0;
        int match2=0;
        for(int i=0;i<qualities.size();i++){
            for(int j=1;j<object1.size();j++)
            {
                if(qualities.get(i).equalsIgnoreCase(object1.get(j)))
                    match1++;

            }
        }
        for(int i=0;i<qualities.size();i++){
            for(int j=1;j<object2.size();j++)
            {
                if(qualities.get(i).equalsIgnoreCase(object2.get(j)))
                    match2++;

            }
        }
        if(match2>match1){
            System.out.println("Це "+object2.get(0)+", так?");
            //checkAnswer();
            String answer="";
            answer=scanner.nextLine();
            if(answer.equalsIgnoreCase("так"))
            {
                System.out.println("Це чудово!");
                addQualities(object2);
            }else{
                System.out.println("О ні!Це "+object1.get(0)+".");
                addQualities(object1);
            }
        }else {
            System.out.println("Це "+object1.get(0)+", так?");
            String answer="";
            answer=scanner.nextLine();
            if(answer.equalsIgnoreCase("так"))
            {
                System.out.println("Це чудово!");
                addQualities(object1);
            }else{
                System.out.println("О ні! Це "+object2.get(0)+".");
                addQualities(object2);
            }
        }
    }

    private static void addQualities(ArrayList<String> list) {
        //boolean switcher=false;
        for(int i=0;i<qualities.size();i++){
            for(int j=1;j<list.size();j++)
            {
                if(qualities.get(i).equalsIgnoreCase(list.get(j))) {
                    //switcher=true;
                    break;
                }
               if(j==list.size()-1 /*&& !switcher*/)
               {
                   list.add(qualities.get(i));
                   break;
               }

            }
            //switcher=false;
        }
    }

    private static void askQualities() {
        System.out.print("Введіть ознаки: ");
        while(true){
            String current = scanner.nextLine();
            if(current.equals(""))break;
            qualities.add(current);
        }
    }

    private static void printQualities() {
        System.out.println("--------------------------------------------------------------");
        for (String s : object1) {
            System.out.println(s);
        }
        System.out.println("--------------------------------------------------------------");
        for (String s : object2) {
            System.out.println(s);
        }
        System.out.println("--------------------------------------------------------------");
    }

    private static void enterStartData() {
        System.out.print("Введіть ім'я першої групи: ");
        object1.add(scanner.nextLine());
        System.out.print("Введіть ім'я другої групи: ");
        object2.add(scanner.nextLine());
        System.out.print("Введіть ознаки першої групи: ");
        object1.add(scanner.nextLine());
        while(true){
            String current = scanner.nextLine();
            if(current.equals(""))break;
            object1.add(current);
        }
        System.out.print("Введіть ознаки другої групи: ");
        while(true){
            String current = scanner.nextLine();
            if(current.equals(""))break;
            object2.add(current);
        }
    }

}
