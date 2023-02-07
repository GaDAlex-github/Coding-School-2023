var selectPostRowEl = rowEl;
//1
function stringReverse() {
    const str = document.getElementById("string1").value;
    let newString = "";
    for (let i = str.length - 1; i >= 0; i--) {
        newString += str[i];
    }
    document.getElementById("Log1").innerHTML = newString;
}
//2
function palindrome() {
    const str = document.getElementById("string2").value;
    let newString = "";
    for (let i = str.length - 1; i >= 0; i--) {
        newString += str[i];
    }
    if (str == newString)
        document.getElementById("Log2").innerHTML = "String is palidrome";
    else document.getElementById("Log2").innerHTML = "String is not palidrome";
}
//3
function newCustomer() {
    var allCustomers = [];
    const table = document.getElementById("tblCustomers");
    const customer = {
        name: document.getElementById("name").value,
        surname: document.getElementById("surname").value,
        age: document.getElementById("age").value,
        gender: document.getElementById("gender").value,
    };
    allCustomers.push(customer);
    createTableRow(customer, table);
}
function createTableRow(customer, tableEl) {
    let rowEl = tableEl.insertRow();

    rowEl.setAttribute("data-id", customer.id);

    rowEl.addEventListener("click", (event) => {
        selectPostRow(event.currentTarget);
    });

    let nameEl = rowEl.insertCell(0);
    nameEl.innerHTML = customer.name;

    let surnameEl = rowEl.insertCell(1);
    surnameEl.innerHTML = customer.surname;

    let ageEl = rowEl.insertCell(2);
    ageEl.innerHTML = customer.age;

    let genderEl = rowEl.insertCell(3);
    genderEl.innerHTML = customer.gender;
}
function selectRow(rowEl) {
    if (selectPostRowEl != undefined) {
        selectPostRowEl.classList.remove("selected");
    }

    selectPostRowEl = rowEl;
    selectPostRowEl.classList.add("selected");
}
//4
function multiply() {
    const num1 = document.getElementById("num1").value;
    const num2 = document.getElementById("num2").value;

    let na = Math.floor(num1);
    let nb = Math.floor(num2);
    let nc = na * nb;

    document.getElementById("Log4").innerHTML = nc;
}
//5
function stringNumber() {
    const str = document.getElementById("string5").value;
    newStr = str.replace(/(\d*)$/, (_, t) =>
        (+t + 1).toString().padStart(t.length, 0)
    );
    document.getElementById("Log5").innerHTML = newStr;
}
