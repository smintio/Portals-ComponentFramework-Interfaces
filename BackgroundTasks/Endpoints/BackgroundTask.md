Description
===========

Gets the result of a background task.

The background task result encapsulates information about the progress and status of an operation. 

It provides insights into the various states of the task execution, along with essentials details such as the final outcome, download URL, error information and completion percentage.

Smint.io implements two types of background tasks: long-running and immediate-execution tasks.

These tasks are designed to perform various operations asynchronously, allowing for efficient handling of resource-intensive processes.

- **Long-Running Tasks**: Long-running tasks are operations that may take a significant amount of time to complete. These tasks are initiated and monitored asynchronously. The status and progress of long-running tasks can be queried repeatedly until they either completed or reach an error state. The result of a long-running task is provided in the `result_string` property upon completion.
    - **Polling Time**: There should be a minimum polling time between each retrieval of a task. While a minimum of 1 second is necessary to avoid excessive polling, it is recommended to set the polling interval between 5 to 10 seconds depending on the specific use case.
    - **Exponential Backoff**: Avoid using exponential backoff strategies for polling. While exponential backoff can help alleviate congestion in some scenarios it is generally not suitable for long-running tasks as it may result in prolonged intervals between task checks leading to delayed processing.
- **Immediate-Execution Tasks**: Immediate-execution tasks are operations that are executed immediately without significant delay. Unlike long-running tasks, immediate-execution tasks typically complete quickly and provide their result promptly. The result of an immediate-execution task is also available in the `result_string` property upon completion.

Learn more about how to access the Swagger documentation for this method [here](../../README.md#swagger-page).

Current version of this document is: 1.0.1 (as of 7th of March, 2024)

## Signature

GET `/backgroundTasks/{backgroundTaskUuid}`

## Mandatory parameters

- `backgroundTaskUuid` - The background task UUID

## Output:

```JSON
{
    "uuid": "00000000-0000-0000-0000-000000000000",
    "state": "completed",
    "finished_percentage": 100,
    "total_steps": 1,
    "succeeded_steps": 1,
    "failed_steps": 0,
    "result_string": "..."
}
```

#### Enums:

##### BackgroundTaskState Enum

An enum representing each state of the background task.

- `created`: Specifies that the background task is in the created state.
- `in_progress`: Specifies that the background task is still running.
- `error`: Specifies that the background task has an error.
- `completed`: Specifies that the background task is completed.

## Error handling

In the Swagger documentation, you can find the status codes and error codes associated with the API operations. In case of errors, appropriate HTTP status codes will be returned along with error details in the response body.

### Example error output:

```json
{
    "error_code": "string",
    "error_message": "string",
    "error_details": {
        "uuid": "string",
        "name": "string"
    }
}
```

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH
