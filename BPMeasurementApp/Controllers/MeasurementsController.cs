using BPMeasurementApp.Entities;
using BPMeasurementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BPMeasurementApp.Controllers
{
    public class MeasurementsController : Controller
    {
        public MeasurementsController(MeasurementDbContext measurementDbContext)
        {
            _measurementDbContext = measurementDbContext;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var allMeasurements = _measurementDbContext.Measurements.Include(m => m.Position).OrderBy(m => m.MeasurementId).ToList();
            ViewData["categoriesAndColors"] = getCategoriesandColorsForMeasurements(_measurementDbContext);
            return View(allMeasurements);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            MeasurementViewModel measurementViewModel = new MeasurementViewModel()
            {
                Positions = _measurementDbContext.Positions.OrderBy(g => g.Name).ToList(),
                ActiveMeasurement = new Measurement()
            };
            return View(measurementViewModel);
        }

        [HttpPost()]
        public IActionResult Create(MeasurementViewModel measurementViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new measurement to the DB:
                _measurementDbContext.Measurements.Add(measurementViewModel.ActiveMeasurement);
                _measurementDbContext.SaveChanges();
                return RedirectToAction("Index", "Measurements");
            }
            else
            {
                measurementViewModel.Positions = _measurementDbContext.Positions.OrderBy(g => g.Name).ToList();
                return View(measurementViewModel);
            }
        }

        [HttpGet()]
        public IActionResult Delete(int id)
        {
            // Find/retrieve/select the measurement to confirm delete view:
            var measurement = _measurementDbContext.Measurements.Find(id);
            return View(measurement);
        }

        [HttpPost()]
        public IActionResult Delete(Measurement measurement)
        {
            // Simply remove the Measurement and then redirect back to the all Measurements view:
            _measurementDbContext.Measurements.Remove(measurement);
            _measurementDbContext.SaveChanges();
            return RedirectToAction("Index", "Measurements");
        }

        [HttpGet()]
        public IActionResult Edit(int id)
        {
            MeasurementViewModel measurementViewModel = new MeasurementViewModel()
            {
                Positions = _measurementDbContext.Positions.OrderBy(g => g.Name).ToList(),
                ActiveMeasurement = _measurementDbContext.Measurements.Find(id)
            };

            return View(measurementViewModel);
        }

        [HttpPost()]
        public IActionResult Edit(MeasurementViewModel measurementViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to update the existing measurement in the DB:
                _measurementDbContext.Measurements.Update(measurementViewModel.ActiveMeasurement);
                _measurementDbContext.SaveChanges();
                return RedirectToAction("Index", "Measurements");
            }
            else
            {
                measurementViewModel.Positions = _measurementDbContext.Positions.OrderBy(g => g.Name).ToList();
                return View(measurementViewModel);
            }
        }

        private Dictionary<int, (string Category, string Color)> getCategoriesandColorsForMeasurements(MeasurementDbContext measurementDbContext)
        {
            Dictionary<int, (string Category, string Color)> categoryAndColorForMeasurements = new Dictionary<int, (string Category, string Color)>();
            foreach (Measurement measurement in measurementDbContext.Measurements)
            {
                if (measurement.Systolic > 180 || measurement.Diastolic > 120)
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Hypertensive Crisis", Color: "darkred");
                }
                else if (measurement.Systolic >= 140 || measurement.Diastolic >= 90)
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Hypertension Stage 2", Color: "orangered");
                }
                else if ((measurement.Systolic <= 139 && measurement.Systolic >= 130) || (measurement.Diastolic <= 89 && measurement.Diastolic >= 80))
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Hypertension Stage 1", Color: "orange");
                }
                else if ((measurement.Systolic <= 129 && measurement.Systolic >= 120) && (measurement.Diastolic < 80))
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Elevated", Color: "blue");
                }
                else if ((measurement.Systolic < 120) && (measurement.Diastolic < 80))
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Normal", Color: "green");
                }
                else
                {
                    categoryAndColorForMeasurements[measurement.MeasurementId] = (Category: "Unclassified", Color: "gray");
                }
            }
            return categoryAndColorForMeasurements;
        }

        private MeasurementDbContext _measurementDbContext;
    }
}
