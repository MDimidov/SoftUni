const {test, expect} = require('@playwright/test');
const url = "http://localhost:3000";

test('Verify All Books link is visible', async ({page}) =>{
    await page.goto(url)
})