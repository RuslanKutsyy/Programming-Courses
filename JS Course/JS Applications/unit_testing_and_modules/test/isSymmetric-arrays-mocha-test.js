let isSymmetric = require("../functions/isSymmetric").isSymmetric;
let expect = require("chai").expect;

describe("isSymmetric(arr) - check if arrays are symmetric", function () {
    it('should return false when argument is not array', function () {
        let expectedResult = false;
        let actualResult = isSymmetric("a");
        expect(actualResult).to.be.eq(expectedResult);
    });
})