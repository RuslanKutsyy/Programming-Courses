function centuryFromYear(year) {
    let century = parseInt(year / 100);
    let years = year % 100;

    if (years > 0) {
        century++;
    }
    
    return century;
}