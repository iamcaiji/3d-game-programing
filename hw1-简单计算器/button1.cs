using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string str = "";
    
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    string caulate(){
    	int num = str.Length;
    	int a = 0, b = 0, index = 0;
    	// string flag;
    	int sum = 0;
    	for (int i = 0;i < num; ++ i){
    		if (str[i] <= '9' && str[i] >= '0'){
    			a = a * 10 + str[i] - '0';
    		}
    		else {
    			index = i;
    			++ i;
    			while(i < num){
    				b = b * 10 + str[i] - '0';
    				++ i;
    			}
    		}
    	}
    	if (str[index] == '+') sum = a + b;
    	else if(str[index] == '-') sum = a - b;
    	else if(str[index] == 'x') sum = a * b;
    	else if(str[index] == '/') sum = a / b;
    	else if(str[index] == '%') sum = a % b;
    	return sum.ToString();
    }
    void OnGUI () 
    {
	   	GUI.Button(new Rect(250, 60, 320, 40), str); 
        if (GUI.Button(new Rect(250, 100, 80, 40), "AC")) {
	  		str = "";
        }
        if (GUI.Button(new Rect(330, 100, 80, 40), "sqrt")) {
        	int sum = 0;
        	for (int i = 0; i < str.Length; ++ i){
        		sum = sum * 10 + str[i] - '0';
        	}
        	float num = Mathf.Sqrt(sum);
        	str = num.ToString();
        }
        if (GUI.Button(new Rect(410, 100, 80, 40), "%")) {
	  		str += "%";
        }
        if (GUI.Button(new Rect(490, 100, 80, 40), "+")) {
	  		str += "+";
        }
        if (GUI.Button(new Rect(250, 140, 80, 40), "9")) {
	  		str += "9";
        }
        if (GUI.Button(new Rect(330, 140, 80, 40), "8")) {
	  		str += "8";
        }
        if (GUI.Button(new Rect(410, 140, 80, 40), "7")) {
	  		str += "7";
        }
        if (GUI.Button(new Rect(490, 140, 80, 40), "-")) {
	  		str += "-";
        }
        if (GUI.Button(new Rect(250, 180, 80, 40), "6")) {
	  		str += "6";
        }
        if (GUI.Button(new Rect(330, 180, 80, 40), "5")) {
	  		str += "5";
        }
        if (GUI.Button(new Rect(410, 180, 80, 40), "4")) {
	  		str += "4";
        }
        if (GUI.Button(new Rect(490, 180, 80, 40), "x")) {
	  		str += "x";
        }
        if (GUI.Button(new Rect(250, 220, 80, 40), "3")) {
	  		str = "";
        }
        if (GUI.Button(new Rect(330, 220, 80, 40), "2")) {
	  		str += "2";
        }
        if (GUI.Button(new Rect(410, 220, 80, 40), "1")) {
	  		str += "1";
        }
        if (GUI.Button(new Rect(490, 220, 80, 40), "/")) {
	  		str += "/";
        }
        if (GUI.Button(new Rect(250, 260, 80, 40), "0")) {
	  		str += "0";
        }
        if (GUI.Button(new Rect(330, 260, 80, 40), ".")) {
	  		str += ".";
        }
        if (GUI.Button(new Rect(410, 260, 80, 40), "-")) {
	  		str += "-";
        }
        if (GUI.Button(new Rect(490, 260, 80, 40), "=")) {
        	str = caulate();
        }
    }
}
