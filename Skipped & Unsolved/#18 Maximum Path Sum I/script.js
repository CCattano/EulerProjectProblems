console.clear();

const screenLog = document.querySelector('#screen-log');
document.addEventListener('mousemove', (e) => { screenLog.innerText = `Client X/Y: ${e.clientX}, ${e.clientY}` });

const start = window.performance.now();
let finish;

const pyramid = [
    [75],
    [95, 64],
    [17, 47, 82],
    [18, 35, 87, 10],
    [20, 04, 82, 47, 65],
    [19, 01, 23, 75, 03, 34],
    [88, 02, 77, 73, 07, 63, 67],
    [99, 65, 04, 28, 06, 16, 70, 92],
    [41, 41, 26, 56, 83, 40, 80, 70, 33],
    [41, 48, 72, 33, 47, 32, 37, 16, 94, 29],
    [53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14],
    [70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57],
    [91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48],
    [63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31],
    [04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23],
];
const canvasEl = document.getElementById("canvas");

function prepareUI() {
    const pyramidContainer = document.getElementById("pyramid");
    pyramid.forEach((row, i) => {
        let rowEl = document.createElement("div");
        rowEl.id = `row${i}`;
        row.forEach((col, ni) => {
            const colStr = col.toString();
            let labelEl = document.createElement("label");
            labelEl.id = `r${i}c${ni}`;
            labelEl.innerText = `${colStr.length === 1 ? `0${colStr}` : colStr}`;
            labelEl.style.paddingLeft = "5px";
            labelEl.style.paddingRight = "5px";
            rowEl.append(labelEl);
        });
        pyramidContainer.append(rowEl);
    });
    window.setTimeout(() => {
        const containerDimensions = document.getElementById("container").getBoundingClientRect();
        canvasEl.height = containerDimensions.height + containerDimensions.top;
        canvasEl.width = containerDimensions.width + containerDimensions.left;
    });
}

prepareUI();

function getCenter(element) {
    const elCoords = element.getBoundingClientRect();
    const centerX = elCoords.left + (elCoords.width / 2);
    const centerY = elCoords.top + (elCoords.height / 2);

    return {
        xCoord: Math.round(centerX),
        yCoord: Math.round(centerY)
    };
}

function drawLine(el1ID, el2ID) {
    //Get elements
    const el1 = document.getElementById(el1ID);
    const el2 = document.getElementById(el2ID);
    //Get Coordinates
    const el1Coords = getCenter(el1);
    console.log(el1Coords);
    const el2Coords = getCenter(el2);
    console.log(el1Coords);
    //Get Drawing Context
    const draw = document.getElementById("canvas").getContext("2d");
    draw.imageSmoothingQuality = "high"
    draw.strokeStyle = "red";
    draw.lineWidth = "2"
    draw.beginPath();
    draw.moveTo(el1Coords.xCoord, el1Coords.yCoord);
    draw.lineTo(el2Coords.xCoord, el2Coords.yCoord);
    draw.stroke();
}

function fillTest() {
    let colIndex = 0;
    pyramid.forEach((row, i) => {
        if (i + 1 !== pyramid.length) {
            const elOneID = `r${i}c${colIndex}`;
            colIndex += (Math.floor(Math.random() * 2));
            const elTwoID = `r${i + 1}c${colIndex}`;
            window.setTimeout(() => { drawLine(elOneID, elTwoID); }, i * 250);
        }
    });
}

fillTest();

let result = 0;

finish = window.performance.now();

function getResultWithCommas(val) {
    let resultStr = val.split("").reverse().map((o, i, a) => (i % 3 === 0) ? `${o},` : o).reverse().join("");
    return resultStr.endsWith(",") ? resultStr.slice(0, -1) : resultStr;
}

document.getElementById("result").innerHTML = `Result goes here`;
document.getElementById("time").innerHTML = `Problem Solved In: ${(finish - start)}ms`;