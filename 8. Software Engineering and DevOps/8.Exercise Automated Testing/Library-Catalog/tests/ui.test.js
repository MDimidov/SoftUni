const {test, expect} = require('@playwright/test');
const url = "http://localhost:3000";

test('Verify All Books link is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get All Books link
    const allBooksLink = await page.$('a[href="/catalog"]');

    // Check if element is visible
    const isElementVisible = await allBooksLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});

test('Verify Log In button is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');

    // Check if element is visible
    const isElementVisible = await loginLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});

test('Verify Register button is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Register link
    const registerLink = await page.$('a[href="/register"]');

    // Check if element is visible
    const isElementVisible = await registerLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});


test('Verify Register link text', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Register link
    const registerLink = await page.$('a[href="/register"]');

    // Get element text
    const elementText = await registerLink.textContent();

    //Verify if the element is visible
    expect(elementText).toEqual("Register");
});

test('Verify valid user can log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    const logoutButton = await page.$('#logoutBtn');

    // Check if element is visible
    const isElementVisible = await logoutButton.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});

test('Verify All Books link & text is visible after log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get All Books link
    const allBooksLink = await page.$('a[href="/catalog"]');

    // Check if element is visible
    const isElementVisible = await allBooksLink.isVisible();

    // Get text element
    const allBooksLinkText = await allBooksLink.textContent();

    //Verify if the element is visible and text is correct
    expect(isElementVisible).toBe(true);
    expect(allBooksLinkText).toBe("All Books");
});

test('Verify My Books link & text is visible after log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get My Books link
    const myBooksLink = await page.$('a[href="/profile"]');

    // Check if element is visible
    const isElementVisible = await myBooksLink.isVisible();

    // Get text element
    const myBooksLinkText = await myBooksLink.textContent();

    //Verify if the element is visible and text is correct
    expect(isElementVisible).toBe(true);
    expect(myBooksLinkText).toEqual('My Books');
});

test('Verify Add Book link & text is visible after log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get My Books link
    const addBookLink = await page.$('a[href="/create"]');

    // Check if element is visible
    const isElementVisible = await addBookLink.isVisible();

    // Get text element
    const addBookLinkText = await addBookLink.textContent();

    //Verify if the element is visible and text is correct
    expect(isElementVisible).toBe(true);
    expect(addBookLinkText).toEqual('Add Book');
});

test('Verify Welcome, user@email text is visible after log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    const userMail = 'peter@abv.bg'
    await page.fill('#email', userMail);
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get My Books link
    const userEmail = await page.$('#user > span');

    // Check if element is visible
    const isElementVisible = await userEmail.isVisible();

    // Get text element
    const userEmailText = await userEmail.textContent();

    //Verify if the element is visible and text is correct
    expect(isElementVisible).toBe(true);
    expect(userEmailText).toEqual(`Welcome, ${userMail}`);
});