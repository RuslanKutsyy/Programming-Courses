package com.company;

import java.lang.reflect.Array;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        ArrayDeque<String> stack = new ArrayDeque<>();
        Scanner scanner = new Scanner(System.in);
        String cmd = scanner.nextLine();
        Integer result = 0;

        String[] expArr = cmd.split(" ");
        Collections.reverse(Arrays.asList(expArr));
        Arrays.asList(expArr).forEach(stack::push);
        result = Integer.parseInt(stack.pop());

        while (stack.size() > 0){
            String sign = stack.pop();
            switch (sign){
                case "+": {
                    result += Integer.parseInt(stack.pop());
                    break;
                }
                case "-": {
                    result -= Integer.parseInt(stack.pop());
                    break;
                }
                default: break;
            }
        }
        System.out.println(result);
    }
}
