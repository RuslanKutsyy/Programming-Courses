let expect = require("chai").expect;
let sum = require("../functions/sum").sum;

describe("sum(arr) - sum array of numbers", function () {
    it('should return 3 for [1, 2]', function () {
        let expectedSum = 3
        let actualSum = sum([1, 2]);
        expect(actualSum).to.be.eq(expectedSum);
    });

    it('should return 1 for [1]', function () {
        let expectedSum = 1;
        let actualSum = sum([1]);
        expect(actualSum).to.be.eq(expectedSum);
    });

    it('should return 0 for empty arr', function () {
        let expectedSum = 0;
        let actualSum = sum([]);
        expect(actualSum).to.be.eq(expectedSum);
    });

    it('should return NaN when one of the string values is converted to Number', function () {
        let actualSum = sum([1, Number("f"), 4]);
        expect(actualSum).to.be.NaN;
    });

    it('should return number when of the values is boolean', function () {
        let expected = 4;
        let actualSum = sum([1, Number(false), 3]);
        expect(actualSum).to.be.eq(expected);
    });

    it('should return number when of the values is NaN', function () {
        let actualSum = sum([1, NaN, 3]);
        expect(actualSum).to.be.NaN;
    });
})