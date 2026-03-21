using ApiAppStudy.Features.Activities.Domain.Entities;
using ApiAppStudy.Features.Activities.Domain.Enums;

namespace ApiAppStudy.Features.Activities.Domain.Specifications
{
    /// <summary>
    /// Especificaciones y reglas de negocio para Activity
    /// </summary>
    public static class ActivitySpecifications
    {
        // Constantes de reglas de negocio
        public const int MinNameLength = 3;
        public const int MaxNameLength = 100;
        public const int MaxDescriptionLength = 500;

        /// <summary>
        /// Valida si el nombre de la actividad es válido
        /// </summary>
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) 
                   && name.Length >= MinNameLength 
                   && name.Length <= MaxNameLength;
        }

        /// <summary>
        /// Valida si la descripción es válida
        /// </summary>
        public static bool IsValidDescription(string description)
        {
            return description.Length <= MaxDescriptionLength;
        }

        /// <summary>
        /// Verifica si una actividad está activa
        /// </summary>
        public static bool IsActive(Activity activity)
        {
            return activity.Status == ActivityStatus.Active && !activity.IsDeleted;
        }

        /// <summary>
        /// Verifica si una actividad puede ser completada
        /// </summary>
        public static bool CanBeCompleted(Activity activity)
        {
            return activity.Status == ActivityStatus.Active && !activity.IsDeleted;
        }

        /// <summary>
        /// Verifica si una actividad puede ser editada
        /// </summary>
        public static bool CanBeEdited(Activity activity)
        {
            return !activity.IsDeleted && activity.Status != ActivityStatus.Completed;
        }

        /// <summary>
        /// Verifica si una actividad puede ser eliminada
        /// </summary>
        public static bool CanBeDeleted(Activity activity)
        {
            return !activity.IsDeleted;
        }
    }
}
