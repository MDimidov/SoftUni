function generateReport() {
    const th = Array.from(document.querySelectorAll("th input"));
    const rows = Array.from(document.querySelectorAll("tbody tr"));
    const output = document.querySelector("#output");

    const columns = {
        employee: 1,
        deparment: 2,
        status: 3,
        dateHired: 4,
        benefits: 5,
        salary: 6,
        rating: 7,
    }

    let result = [];
    for (let i = 0; i < rows.length; i++) {
        const row = Array.from(rows[i].children);
        let object = {};

        for (let j = 0; j < th.length; j++) {
            const column = th[j];

            if (column.checked) {
                object[column.name] = row[j].textContent;
            }
        }

        result.push(object);
    }
    output.textContent = JSON.stringify(result, null, 1);
}

// -----------------Method 2--------------------


function generateReport() {
    const columnNames = Array.from(document.querySelectorAll('thead>tr>th'))
        .map(col => ({
            name: col.textContent.trim().toLowerCase(),
            isChecked: col.querySelector('input').checked,
        }));

    const rows = Array.from(document.querySelectorAll('tbody>tr'));
    const columns = [];

    for (const colTr of rows) {
        const colTd = Array.from(colTr.children).map(c => c.textContent);
        const obj = {};
        for (let i = 0; i < colTd.length; i++) {
            if(columnNames[i].isChecked){
                obj[columnNames[i].name] = colTd[i];
            } 
        }
        columns.push(obj);
    }

    const output = document.querySelector('#output');
    output.textContent = JSON.stringify(columns, null, 1);
}