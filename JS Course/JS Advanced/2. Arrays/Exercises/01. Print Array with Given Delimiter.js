function printArray(data) {
    console.log(data.join(data.pop()));
}

printArray(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']);