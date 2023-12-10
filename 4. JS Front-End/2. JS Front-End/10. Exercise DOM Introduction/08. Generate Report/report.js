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