// const { test, expect } = require('@playwright/test');

const { test, expect } = require('@playwright/test');
const url = 'http://localhost:5500';

// Verify if a user can add a task
test('User can add a task', async ({ page }) => {
    //Add a task
    await page.goto(url);
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    const taskTest = await page.textContent('.task');
    expect(taskTest).toContain('Test Task');
});

// Verify if a user can delete a task
test('User can delete a task', async ({ page }) => {
    // Add a task
    await page.goto(url);
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Delete the task
    await page.click('.task .delete-task');

    // Is task is deleted
    const taskTest = await page.$$eval('.task',
        tasks => tasks.map(task => task.textContent));
    expect(taskTest).not.toContain('Test Task');
});

// Verify if a user can mark a task as completed
 test('User can mark a task as completed', async ({ page }) => {
    // Add a task
    await page.goto(url);
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Mark a task as completed
    await page.click('.task .task-complete');

    // Is task is completed
    const completeTask = await page.$('.task.completed');
    expect(completeTask).not.toBeNull();
});

// Verify if a user can filter tasks
test('User can filter tasks', async ({ page }) => {
    // Add a task
    await page.goto(url);
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    // Mark a task as completed
    await page.click('.task .task-complete');

    // Filter task
    await page.selectOption('#filter', 'Completed');

    // Is task is completed
    const incompleteTask = await page.$('.task:not(.completed)');
    expect(incompleteTask).toBeNull();
});