.NET-CNPagedList
================

A simple class that accepts a collection of items and paginates the results. This is useful when returning a paginated list from a WebApi project.

Usage
================
To create a paginated list:
CNPagedList<Model> pagedList = new CNPagedList<Model>(items, page, pageLimit);

The parameters page and pageLimit are optional. If they are not provided, the CNPagedList will contain all of the items.

JSON Example
================
This is an example of a response returned from the WebApi.

... assume we specify page size of 3, and there are a total of 10 items ...

{
  "items": [
    {
      "name":"Item 1"
    },
    {
      "name":"Item 2"
    },
    {
      "name":"Item 3"
    }
  ],
  "page": 1,
  "pageSize":3,
  "totalItemCount":10
}
