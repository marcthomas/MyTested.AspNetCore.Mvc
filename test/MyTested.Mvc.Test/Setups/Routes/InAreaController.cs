﻿namespace MyTested.Mvc.Tests.Setups.Routes
{
    using Microsoft.AspNet.Mvc;

    [Area("MyArea")]
    public class InAreaController
    {
        public IActionResult Action(int id)
        {
            return null;
        }
    }
}
