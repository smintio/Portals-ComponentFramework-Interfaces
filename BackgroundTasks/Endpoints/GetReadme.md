Description
===========

Gets the result of a background task.

The background task result encapsulates information about the progress and status of an operation. 
It provides insights into the various states of the task execution, along with essentials details such as the final outcome, download URL, error information and completion percentage.

Smint.io implements two types of background tasks: long-running and immediate-execution tasks.
These tasks are designed to perform various operations asynchronously, allowing for efficient handling of resource-intensive processes.

- **Long-Running Tasks**: Long-running tasks are operations that may take a significant amount of time to complete. These tasks are initiated and monitored asynchronously. The status and progress of long-running tasks can be queried repeatedly until they either completed or reach an error state. The result of a long-running task is provided in the `result_string` property upon completion.
- **Immediate-Execution Tasks**: Immediate-execution tasks are operations that are executed immediately without significant delay. Unlike long-running tasks, immediate-execution tasks typically complete quickly and provide their result promptly. The result of an immediate-execution task is also available in the `result_string` property upon completion.

Swagger documentation can be found at `https://{tenant}.smint.io/apidocs/index.html` or see how to get the full URL [here](../../README.md#swagger-page).
- Replace `{tenant}` with the target environment e.g. `demo`
- Select `Smint.io Portals Frontend Api` from the definition selection dropdown
- Find and expand `Background Tasks`
- Expand `Get background task information`

Current version of this document is: 1.0.0 (as of 1st of March, 2024)

## Signature

GET `/backgroundTasks/{backgroundTaskUuid}`

## Mandatory Parameters

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

## Error Handling

In the Swagger documentation, you can find the status codes and error codes associated with the API operations. In case of errors, appropriate HTTP status codes will be returned along with error details in the response body.

### Example Error Output:

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
